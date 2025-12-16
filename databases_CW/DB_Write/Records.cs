using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace databases_CW.DB_Write
{
    public class Records
    {
        public bool AddRecord(string tableName, string connectionString, Dictionary<string, object> values)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    var columns = string.Join(", ", values.Keys);
                    var parameters = string.Join(", ", values.Keys.Select(k => "@" + k));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters}) RETURNING id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        foreach (var kvp in values)
                        {
                            if (kvp.Value == null || (kvp.Value is string str && string.IsNullOrWhiteSpace(str)))
                                command.Parameters.AddWithValue("@" + kvp.Key, DBNull.Value);
                            else
                                command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                        }

                        var newId = command.ExecuteScalar();
                        return newId != null;
                    }
                }
            }
            catch (PostgresException ex)
            {
                MessageBox.Show($"Ошибка PostgreSQL при добавлении записи: {ex.Message}\nКод ошибки: {ex.SqlState}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления записи: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteRecord(string tableName, string connectionString, int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"DELETE FROM {tableName} WHERE id = @id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления записи: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateRecord(string tableName, string connectionString, int id, Dictionary<string, object> values)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    var setClause = string.Join(", ", values.Keys.Select(k => $"{k} = @{k}"));
                    string query = $"UPDATE {tableName} SET {setClause} WHERE id = @id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        foreach (var kvp in values)
                        {
                            if (kvp.Value == null || kvp.Value == DBNull.Value)
                            {
                                command.Parameters.AddWithValue("@" + kvp.Key, DBNull.Value);
                            }
                            else if (kvp.Value is string str && string.IsNullOrWhiteSpace(str))
                            {
                                command.Parameters.AddWithValue("@" + kvp.Key, DBNull.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                            }
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (PostgresException ex)
            {
                MessageBox.Show($"Ошибка PostgreSQL: {ex.Message}\nДетали: {ex.Detail}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления записи: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public DataTable FilterRecords(string tableName, string connectionString,
                DataGridView dataGridView, string searchText, string columnName)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM {tableName} WHERE {columnName} LIKE @searchText ORDER BY id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchText", $"%{searchText}%");

                        var dataTable = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        dataGridView.DataSource = dataTable;

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка фильтрации записей: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
