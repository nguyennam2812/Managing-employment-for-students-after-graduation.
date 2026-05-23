using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien.Data
{
    internal static class SqlConnectionFactory
    {
        // Preferred database name if no config is provided
        private const string DefaultDatabaseName = "QLyViecLamSV";

        // Candidates to try in order. Covers common LocalDB and SQL Express installs.
        private static readonly string[] DataSources = new[]
        {
            "(localdb)\\MSSQLLocalDB",
            "(localdb)\\v11.0",
            "(localdb)\\ProjectsV13",
            ".\\SQLEXPRESS",
            ".",
            "localhost"
        };

        public static SqlConnection CreateDefault()
        {
            var enableLocalFallback = string.Equals(
                ConfigurationManager.AppSettings["EnableLocalFallback"],
                "true",
                StringComparison.OrdinalIgnoreCase);

            // 1) Try connection string from App.config if present
            var configured = TryCreateFromConfig(out var configuredError, out var hadConfiguredConnection, out var isLocalIntegrated);
            if (configured != null) return configured;

            // Nếu có chuỗi kết nối nhưng lỗi, không fallback sang LocalDB (tránh “đăng nhập offline”)
            if (hadConfiguredConnection)
            {
                throw new InvalidOperationException(
                    "Không thể sử dụng chuỗi kết nối 'DefaultConnection'. Vui lòng kiểm tra lại thông tin máy chủ/CSDL hoặc quyền truy cập.",
                    configuredError);
            }

            // Nếu không cấu hình connection string và không cho phép fallback, báo lỗi rõ ràng
            if (!enableLocalFallback)
            {
                throw new InvalidOperationException(
                    "Thiếu chuỗi kết nối 'DefaultConnection' trong App.config (hoặc UserSecrets). Đã tắt fallback LocalDB để tránh dùng dữ liệu cục bộ.");
            }

            Exception lastError = configuredError;
            foreach (var ds in DataSources)
            {
                try
                {
                    // First connect to master to validate server availability
                    var masterBuilder = new SqlConnectionStringBuilder
                    {
                        DataSource = ds,
                        InitialCatalog = "master",
                        IntegratedSecurity = true,
                        MultipleActiveResultSets = true
                    };

                    using (var master = new SqlConnection(masterBuilder.ConnectionString))
                    {
                        master.Open();
                        EnsureDatabaseExists(master, DefaultDatabaseName);
                    }

                    // If we get here, server is reachable and DB exists (or was created)
                    var dbBuilder = new SqlConnectionStringBuilder
                    {
                        DataSource = ds,
                        InitialCatalog = DefaultDatabaseName,
                        IntegratedSecurity = true,
                        MultipleActiveResultSets = true
                    };

                    var connection = new SqlConnection(dbBuilder.ConnectionString);
                    // Don't open here; EF will manage the connection lifecycle
                    return connection;
                }
                catch (Exception ex)
                {
                    lastError = ex;
                    // Try next data source
                }
            }

            // If all candidates failed, throw a clear error
            throw new InvalidOperationException(
                "Không thể kết nối SQL Server/LocalDB. Vui lòng cài đặt SQL Server Express LocalDB hoặc cập nhật lại connection string trong App.config (name=DefaultConnection).",
                lastError);
        }

        private static void EnsureDatabaseExists(SqlConnection masterConnection, string databaseName)
        {
            using (var cmd = masterConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"IF DB_ID(@db) IS NULL EXEC('CREATE DATABASE [' + @db + ']')";
                cmd.Parameters.AddWithValue("@db", databaseName);
                cmd.ExecuteNonQuery();
            }
        }

        private static SqlConnection TryCreateFromConfig(out Exception error, out bool hasConfiguredConnection, out bool isLocalIntegrated)
        {
            error = null;
            hasConfiguredConnection = false;
            isLocalIntegrated = false;
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
                if (string.IsNullOrWhiteSpace(cs)) return null;

                hasConfiguredConnection = true;

                var b = new SqlConnectionStringBuilder(cs);
                var ds = string.IsNullOrWhiteSpace(b.DataSource) ? "(localdb)\\MSSQLLocalDB" : b.DataSource;
                var db = string.IsNullOrWhiteSpace(b.InitialCatalog) ? DefaultDatabaseName : b.InitialCatalog;
                isLocalIntegrated = b.IntegratedSecurity && IsLocalDataSource(ds);

                // Allow remote SQL usage without master/CREATE DATABASE attempts
                bool disableAutoCreate = false;
                bool.TryParse(ConfigurationManager.AppSettings["DisableAutoCreateDatabase"], out disableAutoCreate);
                var skipAutoCreate = disableAutoCreate || !b.IntegratedSecurity || !IsLocalDataSource(ds);

                if (skipAutoCreate)
                {
                    // Use the provided connection string as-is (commonly remote SQL with SQL Auth)
                    return new SqlConnection(b.ConnectionString);
                }

                // Validate server and ensure DB exists (local/dev scenarios)
                var masterBuilder = new SqlConnectionStringBuilder(b.ConnectionString)
                {
                    DataSource = ds,
                    InitialCatalog = "master"
                };

                using (var master = new SqlConnection(masterBuilder.ConnectionString))
                {
                    master.Open();
                    EnsureDatabaseExists(master, db);
                }

                var finalBuilder = new SqlConnectionStringBuilder(b.ConnectionString)
                {
                    DataSource = ds,
                    InitialCatalog = db
                };
                return new SqlConnection(finalBuilder.ConnectionString);
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        private static bool IsLocalDataSource(string dataSource)
        {
            if (string.IsNullOrWhiteSpace(dataSource)) return false;

            var ds = dataSource.Trim();
            if (ds.StartsWith("(localdb)\\", StringComparison.OrdinalIgnoreCase)) return true;
            if (ds.StartsWith(".\\", StringComparison.OrdinalIgnoreCase)) return true;

            return ds.Equals(".", StringComparison.OrdinalIgnoreCase)
                   || ds.Equals("(local)", StringComparison.OrdinalIgnoreCase)
                   || ds.StartsWith("localhost", StringComparison.OrdinalIgnoreCase)
                   || ds.StartsWith("127.0.0.1", StringComparison.OrdinalIgnoreCase);
        }
    }
}
