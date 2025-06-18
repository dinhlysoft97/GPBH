using System;
using System.Collections.Generic;

namespace GPBH.UI.Helper
{
    public static class AppConfigHelper
    {
        public static ConnectionInfo ParseSqlConnectionString(string connStr)
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var part in connStr.Split(';'))
            {
                var kv = part.Split(new[] { '=' }, 2);
                if (kv.Length == 2)
                    dict[kv[0].Trim()] = kv[1].Trim();
            }

            // Lấy host và port từ data source
            // ví dụ: localhost\THUHUYNH hoặc 192.168.1.2,1433
            string host = "", port = "";
            if (dict.TryGetValue("data source", out string dataSource) || dict.TryGetValue("server", out dataSource))
            {
                // Xử lý trường hợp dataSource dạng "host,port" hoặc "host\instance"
                string[] dsParts = dataSource.Split(',');
                host = dsParts[0];
                if (dsParts.Length > 1)
                    port = dsParts[1];
                // Nếu là host\instance thì chỉ lấy host
                if (host.Contains(@"\"))
                    host = host.Split('\\')[0];
            }

            // Lấy database name
            string dbName = "";
            if (!dict.TryGetValue("initial catalog", out dbName))
                dict.TryGetValue("database", out dbName);

            return new ConnectionInfo
            {
                Host = host,
                Port = port,
                Database = dbName
            };
        }
    }

    public class ConnectionInfo
    {
        public string Host { get; set; }
        public string Port { get; set; }   // Nếu không có port sẽ để rỗng
        public string Database { get; set; }
    }

}
