using System;
using DotNetEnv;
using Npgsql;

namespace IAT_Test
{
    internal class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            // Загрузка .env файла только для development среды
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                Env.Load();
            }

            // Получение параметров с проверкой на null
            string host = GetEnvVariable("DB_HOST");
            string database = GetEnvVariable("DB_NAME");
            string user = GetEnvVariable("DB_USER");
            string password = GetEnvVariable("DB_PASSWORD");
            string port = GetEnvVariable("DB_PORT", "5432"); // Порт по умолчанию

            // Используем NpgsqlConnectionStringBuilder для безопасного построения строки
            var builder = new Npgsql.NpgsqlConnectionStringBuilder
            {
                Host = host,
                Database = database,
                Username = user,
                Password = password,
                Port = int.Parse(port),
                SslMode = Npgsql.SslMode.Prefer, // Используем SSL
                TrustServerCertificate = false,
                Pooling = true // Включение пула соединений
            };

            return builder.ConnectionString;
        }

        private static string GetEnvVariable(string name, string defaultValue = null)
        {
            var value = Environment.GetEnvironmentVariable(name)
                      ?? throw new ArgumentNullException($"Environment variable {name} is not set");

            return string.IsNullOrWhiteSpace(value)
                ? defaultValue ?? throw new ArgumentNullException($"Environment variable {name} is empty")
                : value;
        }
    }
}