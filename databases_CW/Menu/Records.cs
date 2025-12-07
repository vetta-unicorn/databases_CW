using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace databases_CW.Menu
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

                    // Создаем параметризованный запрос
                    var columns = string.Join(", ", values.Keys);
                    var parameters = string.Join(", ", values.Keys.Select(k => "@" + k));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters}) RETURNING id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        foreach (var kvp in values)
                        {
                            command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }

                        var newId = command.ExecuteScalar();
                        return newId != null;
                    }
                }
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

                    // Создаем SET часть запроса
                    var setClause = string.Join(", ", values.Keys.Select(k => $"{k} = @{k}"));

                    string query = $"UPDATE {tableName} SET {setClause} WHERE id = @id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        foreach (var kvp in values)
                        {
                            command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления записи: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public DataTable FilterRecords(string tableName, string connectionString,
    DataGridView dataGridView, string searchText)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Используем LIKE для поиска по частичному совпадению
                    string query = $"SELECT * FROM {tableName} WHERE name LIKE @searchText ORDER BY id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем % для поиска по части строки
                        command.Parameters.AddWithValue("@searchText", $"%{searchText}%");

                        var dataTable = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Обновляем DataGridView
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
