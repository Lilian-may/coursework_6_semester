using DotNetEnv;
using Npgsql;

namespace IAT_Test
{
    internal class DatabaseHelper
    {
        private static int currentParticipantId = -1;
        private static int currentViewId = -1;
        private static bool isNewParticipant = true;

        public static string GetConnectionString()
        {
            // Загрузка .env файла только для development среды
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                Env.Load();
            }

            string host = GetEnvVariable("DB_HOST", "127.0.0.1");
            string database = GetEnvVariable("DB_NAME");
            string user = GetEnvVariable("DB_USER");
            string password = GetEnvVariable("DB_PASSWORD");
            string port = GetEnvVariable("DB_PORT", "5432"); // Порт по умолчанию

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Database = database,
                Username = user,
                Password = password,
                Port = int.Parse(port),
                SslMode = SslMode.Prefer,
                Pooling = true
            };

            return builder.ConnectionString;
        }

        private static string GetEnvVariable(string name, string? defaultValue = null)
        {
            var value = Environment.GetEnvironmentVariable(name)
                      ?? throw new ArgumentNullException($"Environment variable {name} is not set");

            return string.IsNullOrWhiteSpace(value)
                ? defaultValue ?? throw new ArgumentNullException($"Environment variable {name} is empty")
                : value;
        }

        public static void ResetParticipantState()
        {
            isNewParticipant = true;
            currentParticipantId = -1;
            currentViewId = -1;
        }

        public static void SaveResults(
            int? age, string gender, string occupation,
            string videoFileName, string faculty, string studyForm, 
            int? course, TimeSpan viewTime, string[] scores)
        {
            try
            {
                using (var conn = new NpgsqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        if (isNewParticipant)
                        {
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO participants (Name, Age, Gender, Occupation) 
                                  VALUES (@name, @age, @gender, @occupation) 
                                  RETURNING Id", conn, tran))
                            {
                                currentParticipantId = Convert.ToInt32(cmd.ExecuteScalar());
                                cmd.Parameters.AddWithValue("age", age ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("gender", gender);
                                cmd.Parameters.AddWithValue("occupation", occupation);
                                cmd.Parameters.AddWithValue("name", currentParticipantId);
                                isNewParticipant = false;
                            }
                        }

                        int videoId;
                        using (var cmd = new NpgsqlCommand(
                            "SELECT Id FROM videos WHERE FileName = @fileName", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("fileName", videoFileName);
                            var result = cmd.ExecuteScalar();
                            if (result == null)
                                throw new Exception($"Видео '{videoFileName}' не найдено в базе данных.");
                            videoId = Convert.ToInt32(result);
                        }

                        using (var cmd = new NpgsqlCommand(
                            @"INSERT INTO views (ParticipantId, VideoId, ViewStart, ViewEnd) 
                              VALUES (@participantId, @videoId, @viewTime)
                              RETURNING Id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("participantId", currentParticipantId);
                            cmd.Parameters.AddWithValue("videoId", videoId);
                            cmd.Parameters.AddWithValue("viewTime", viewTime);
                            currentViewId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        for (int i = 0; i < scores.Length && i < scores.Length; i++)
                        {
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO ratings (ViewId, Score) 
                                  VALUES (@viewId, @score)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("viewId", currentViewId);
                                cmd.Parameters.AddWithValue("score", scores[i]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}");
            }
        }
    }
}
