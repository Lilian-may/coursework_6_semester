using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace IAT_Test
{
    using DotNetEnv;
    using OfficeOpenXml;
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            Env.Load();

            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string database = Environment.GetEnvironmentVariable("DB_NAME");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            return $"Server={server};Database={database};User Id={user};Password={password};";
        }
    }

}
