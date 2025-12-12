using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databases_CW.Menu;
using databases_CW.DB_Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;

namespace databases_CW.DB
{
    public class DB_Dicrectories
    {
        // имя id -- имя таблицы
        public Dictionary<string, string> IdToTableName = new Dictionary<string, string>()
        {
            { "city", "cities"},
            { "street", "streets" },
            { "bank", "banks" }
        };

        public List<string> referenceTables = new List<string>()
        {
            "cities",
            "streets",
            "banks",
            "job",
            "post",
            "profession",
            "qualification",
            "specialization",
            "structural_division"
        };

        public Dictionary<string, List<string>> tableForeignKeys = new Dictionary<string, List<string>>
        {
            { "author_book", new List<string> { "author_id", "book_id" } },
            { "items", new List<string> { "book_id" } },
            { "boght_items", new List<string> {"book_id"} },
            { "available_books", new List<string> { "book_id" } },
            { "individuals", new List<string> { "customer_id" } },
            { "legal_entity", new List<string> { "customer_id", "bank_id", "city_id", "street_id" } },
            { "orders", new List<string> {"customer_id"} },
            { "employees", new List<string> { "city_id", "street_id" } },
            { "suppliers", new List<string> { "bank_id", "city_id", "street_id" } },
            { "supplies", new List<string> { "supplier_id" } },
            { "supply_item", new List<string> { "item_id", "supply_id" } },
            { "work_book", new List<string>
                { "employee_id", "job_id", "structural_division_id", "post_id",
                  "profession_id", "specialization_id", "qualification_id"} }
        };

        public void LoadAndReplaceForeignKeys(string tableName, string connectionString,
                                               DataGridView dataGridView)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    List<string> foreignKeys = new List<string>(); // лист всех внешних ключей
                    if (tableForeignKeys.ContainsKey(tableName))
                    {
                        foreignKeys = tableForeignKeys[tableName];
                    }
                    StringBuilder queryBuilder = new StringBuilder("SELECT ");

                    string getColumnsQuery = $@"
                        SELECT column_name 
                        FROM information_schema.columns 
                        WHERE table_name = '{tableName}' 
                        ORDER BY ordinal_position";

                    var allColumns = new List<string>(); // все колонки таблицы
                    using (var cmd = new NpgsqlCommand(getColumnsQuery, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allColumns.Add(reader.GetString(0));
                        }
                    }

                    var selectColumns = new List<string>(); // колонки для замены id -> name
                    foreach (var column in allColumns)
                    {
                        if (foreignKeys.Contains(column) && column.EndsWith("_id"))
                        {
                            var refTableName = column.Replace("_id", "");
                            if (referenceTables.Contains(refTableName)) // только справочники
                            {
                                selectColumns.Add($"t.{column}");
                                selectColumns.Add($"ref_{refTableName}.name AS {column.Replace("_id", "_name")}");
                            }
                            else if (IdToTableName.ContainsKey(refTableName))
                            {
                                string tabName = IdToTableName[refTableName];
                                selectColumns.Add($"t.{column}");
                                selectColumns.Add($"ref_{tabName}.name AS {column.Replace("_id", "_name")}");
                            }
                            else
                            {
                                selectColumns.Add($"t.{column}"); // остальные колонки с foreign key
                            }
                        }
                        else
                        {
                            selectColumns.Add($"t.{column}"); // все остальные колонки
                        }
                    }

                    queryBuilder.Append(string.Join(", ", selectColumns));
                    queryBuilder.Append($" FROM \"{tableName}\" t"); // JOIN запрос для замены id -> name 

                    foreach (var fk in foreignKeys.Where(f => f.EndsWith("_id")))
                    {
                        var refTableName = fk.Replace("_id", "");
                        // если такая таблица есть
                        if (referenceTables.Contains(refTableName))
                        {
                            queryBuilder.Append($" LEFT JOIN \"{refTableName}\" ref_{refTableName} ON t.{fk} = ref_{refTableName}.id");
                        }
                        // если такая таблица есть в словаре
                        else if (IdToTableName.ContainsKey(refTableName))
                        {
                            string tabName = IdToTableName[refTableName];
                            queryBuilder.Append($" LEFT JOIN \"{tabName}\" ref_{tabName} ON t.{fk} = ref_{tabName}.id");
                        }
                    }

                    string query = queryBuilder.ToString();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        var dataTable = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        dataGridView.DataSource = dataTable;
                        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView.Visible = true;
                        
                        // убрать ненужные id колонки
                        foreach (DataGridViewColumn gridColumn in dataGridView.Columns)
                        {
                            if (gridColumn.Name.EndsWith("_id") && 
                                foreignKeys.Contains(gridColumn.Name))
                            {
                                var refTableName = gridColumn.Name.Replace("_id", "");
                                if (referenceTables.Contains(refTableName))
                                {
                                    gridColumn.Visible = false;
                                }
                                else if (IdToTableName.ContainsKey(refTableName))
                                {
                                    gridColumn.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
