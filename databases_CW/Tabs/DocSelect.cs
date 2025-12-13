using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Tabs
{
    public class DocSelect
    {
        public string connectionString {  get; set; }
        public DocSelect(string connectStr)
        {
            connectionString = connectStr;
        }
        public void DoSelect(DataGridView dataGridViewReferences, string selectString)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"{selectString}";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        var dataTable = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

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
