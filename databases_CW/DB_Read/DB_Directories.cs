using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databases_CW.Menu;

namespace databases_CW.DB
{
    public class DB_Dicrectories
    {
        public void LoadTableData(string tableName, string connectionString, DataGridView dataGridViewReferences)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tableName}";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        var dataTable = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Настройка DataGridView
                        dataGridViewReferences.DataSource = dataTable;
                        dataGridViewReferences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridViewReferences.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
