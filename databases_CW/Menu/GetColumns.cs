using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class GetColumns
    {
        public string connectionString {  get; set; }
        public GetColumns(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Dictionary<string, List<string>> GetAllTablesColumns()
        {
            var result = new Dictionary<string, List<string>>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 
                t.table_name,
                c.column_name
            FROM 
                information_schema.tables t
            JOIN 
                information_schema.columns c ON t.table_name = c.table_name 
                AND t.table_schema = c.table_schema
            WHERE 
                t.table_schema = 'public' 
                AND t.table_type = 'BASE TABLE'
            ORDER BY 
                t.table_name, 
                c.ordinal_position";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        string currentTable = null;
                        List<string> currentColumns = null;

                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            string columnName = reader.GetString(1);

                            if (currentTable != tableName)
                            {
                                if (currentTable != null)
                                {
                                    result[currentTable] = currentColumns;
                                }

                                currentTable = tableName;
                                currentColumns = new List<string>();
                            }

                            currentColumns.Add(columnName);
                        }

                        if (currentTable != null)
                        {
                            result[currentTable] = currentColumns;
                        }
                    }
                }
            }

            return result;
        }

        public List<string> GetTableColumns(string tableName)
        {
            var columns = new List<string>();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для получения информации о колонках таблицы
                    string query = @"
                SELECT column_name 
                FROM information_schema.columns 
                WHERE table_name = @tableName 
                AND table_schema = 'public'
                ORDER BY ordinal_position";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tableName", tableName);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string columnName = reader.GetString(0);
                                columns.Add(columnName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении колонок таблицы '{tableName}': {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return columns;
        }
    }
}
