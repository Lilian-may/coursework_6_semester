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
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                Env.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".env"));
            }

            string host = GetEnvVariable("DB_HOST", "localhost");
            string database = GetEnvVariable("DB_NAME", "iat_test");
            string user = GetEnvVariable("DB_USER", "postgres");
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
                                @"INSERT INTO participants (name, age, gender, occupation) 
                                  VALUES (@name, @age, @gender, @occupation) 
                                  RETURNING Id", conn, tran))
                            {

                                cmd.Parameters.AddWithValue("name", 'p');
                                cmd.Parameters.AddWithValue("age", age ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("gender", gender);
                                cmd.Parameters.AddWithValue("occupation", occupation);

                                currentParticipantId = Convert.ToInt32(cmd.ExecuteScalar());
                                isNewParticipant = false;
                            }
                        }

                        int videoId;
                        using (var cmd = new NpgsqlCommand(
                            "SELECT id FROM videos WHERE FileName = @fileName", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("fileName", videoFileName);
                            var result = cmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                // Insert new video if it doesn't exist
                                using (var insertCmd = new NpgsqlCommand(
                                    "INSERT INTO videos (FileName, CategoryId) VALUES (@fileName, @categoryId) RETURNING id",
                                    conn, tran))
                                {
                                    insertCmd.Parameters.AddWithValue("fileName", videoFileName);
                                    insertCmd.Parameters.AddWithValue("categoryId", 1); // Default category
                                    videoId = Convert.ToInt32(insertCmd.ExecuteScalar());
                                }
                            }
                            else
                            {
                                videoId = Convert.ToInt32(result);
                            }
                        }

                        using (var cmd = new NpgsqlCommand(
                            @"INSERT INTO views (participantid, videoid, viewtime) 
                              VALUES (@participantid, @videoid, @viewtime)
                              RETURNING Id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("participantid", currentParticipantId);
                            cmd.Parameters.AddWithValue("videoid", videoId);
                            cmd.Parameters.AddWithValue("viewtime", viewTime);
                            currentViewId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        for (int i = 0; i < scores.Length && i < scores.Length; i++)
                        {
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO ratings (viewid, score) 
                                  VALUES (@viewid, @score)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("viewid", currentViewId);
                                cmd.Parameters.AddWithValue("score", Convert.ToInt32(scores[i]));
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
