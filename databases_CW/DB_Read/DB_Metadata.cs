using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.DB_Read
{
    public class ColumnMetadata
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        public int MaxLength { get; set; }
    }

    public class DatabaseMetadataService
    {
        private readonly string _connectionString;

        public DatabaseMetadataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ColumnMetadata> GetTableColumns(string tableName)
        {
            var columns = new List<ColumnMetadata>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                SELECT 
                    column_name,
                    data_type,
                    is_nullable,
                    character_maximum_length
                FROM information_schema.columns
                WHERE table_name = @tableName
                ORDER BY ordinal_position";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tableName", tableName.ToLower());

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var column = new ColumnMetadata
                            {
                                ColumnName = reader["column_name"].ToString(),
                                DataType = reader["data_type"].ToString(),
                                IsNullable = reader["is_nullable"].ToString().ToUpper() == "YES",
                                MaxLength = reader["character_maximum_length"] != DBNull.Value
                                          ? Convert.ToInt32(reader["character_maximum_length"])
                                          : -1
                            };
                            columns.Add(column);
                        }
                    }
                }
            }

            return columns;
        }

        public object ConvertToColumnType(string dataType, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DBNull.Value;

            try
            {
                dataType = dataType.ToLower();

                if (dataType.StartsWith("character varying") || dataType == "varchar")
                    return value;
                else if (dataType == "character" || dataType == "char" || dataType == "text")
                    return value;
                else if (dataType == "integer" || dataType == "int" || dataType == "int4")
                {
                    if (int.TryParse(value, out int intValue))
                        return intValue;
                    else if (string.IsNullOrWhiteSpace(value) || value == "null")
                        return DBNull.Value;
                }
                else if (dataType == "smallint" || dataType == "int2")
                {
                    if (short.TryParse(value, out short shortValue))
                        return shortValue;
                }
                else if (dataType == "bigint" || dataType == "int8")
                {
                    if (long.TryParse(value, out long longValue))
                        return longValue;
                }
                else if (dataType == "boolean" || dataType == "bool")
                {
                    if (bool.TryParse(value, out bool boolValue))
                        return boolValue;
                    else if (value == "1" || value.ToLower() == "true" || value.ToLower() == "t")
                        return true;
                    else if (value == "0" || value.ToLower() == "false" || value.ToLower() == "f")
                        return false;
                    else if (string.IsNullOrWhiteSpace(value))
                        return DBNull.Value;
                }
                else if (dataType.Contains("decimal") || dataType.Contains("numeric"))
                {
                    if (decimal.TryParse(value, out decimal decimalValue))
                        return decimalValue;
                }
                else if (dataType == "real" || dataType == "float4")
                {
                    if (float.TryParse(value, out float floatValue))
                        return floatValue;
                }
                else if (dataType == "double precision" || dataType == "float8")
                {
                    if (double.TryParse(value, out double doubleValue))
                        return doubleValue;
                }
                else if (dataType == "date")
                {
                    if (DateTime.TryParse(value, out DateTime dateValue))
                        return DateOnly.FromDateTime(dateValue);
                }
                else if (dataType == "timestamp" || dataType == "timestamptz")
                {
                    if (DateTime.TryParse(value, out DateTime timestampValue))
                        return timestampValue;
                }
                else if (dataType == "time" || dataType == "timetz")
                {
                    if (TimeSpan.TryParse(value, out TimeSpan timeValue))
                        return timeValue;
                }
                else if (dataType == "bytea")
                {
                    return Encoding.UTF8.GetBytes(value);
                }
                return value;
            }
            catch
            {
                return value;
            }
        }
    }
}
