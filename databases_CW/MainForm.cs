using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using databases_CW.Menu;
using Npgsql;
using databases_CW.DB;

namespace databases_CW
{
    public partial class MainForm : Form
    {
        private delegate void PrintDelegate(string message);
        private string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";
        private DB_Dicrectories directories = new DB_Dicrectories();
        private string currentTableName;
        public MainForm()
        {
            InitializeComponent();
            dataGridViewReferences.CellDoubleClick += dataGridViewReferences_CellDoubleClick;
            TableMenu table = new TableMenu();
            table.SetMenu();
            InitializeMenuStrip(table.menu);
            menuStrip1.BackColor = Color.FromArgb(224, 255, 255);
            menuStrip1.Font = new Font("STFangsong", 12f, FontStyle.Regular);
        }

        public void SetStatus(ToolStripMenuItem menuitem, Tree tree)
        {
            menuitem.Visible = true;
            menuitem.Enabled = true;
            //string jsonstring = file.readalltext(curruserpath);
            //user curruser = jsonserializer.deserialize<user>(jsonstring);
            //int status = authorize.getaccesslevel(tree.root.name, curruser);
            //switch (status)
            //{
            //    case 0:
            //        menuitem.visible = true;
            //        menuitem.enabled = true;
            //        break;
            //    case 1:
            //        menuitem.visible = true;
            //        menuitem.enabled = false;
            //        break;
            //    case 2:
            //        menuitem.visible = false;
            //        menuitem.enabled = false;
            //        break;
            //    case -1:
            //        messagebox.show("unable to set entry status!");
            //        break;
            //}
        }

        private void InitializeMenuStrip(List<Tree> trees)
        {
            foreach (var tree in trees)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(tree.root.name);
                PrintDelegate printMethod;

                if (tree.children == null || tree.children.Count() == 0)
                {
                    printMethod = (message) =>
                    {
                        MessageBox.Show($"You have calles method: {message}");
                    };
                }

                else
                {
                    printMethod = (message) => { };
                }

                menuItem.Click += (sender, e) => printMethod(tree.root.function_name);
                SetStatus(menuItem, tree);

                if (tree.children != null && tree.children.Count > 0)
                {
                    InitializeSubMenu(menuItem, tree.children);
                }

                menuStrip1.Items.Add(menuItem);
            }
        }

        private void InitializeSubMenu(ToolStripMenuItem parentMenuItem, List<Tree> children)
        {
            foreach (var child in children)
            {
                ToolStripMenuItem childMenuItem = new ToolStripMenuItem(child.root.name);

                // Убираем делегат PrintDelegate и используем прямое назначение события
                if (child.children == null || child.children.Count() == 0)
                {
                    // Если это конечный пункт меню (таблица-справочник)
                    childMenuItem.Click += (sender, e) =>
                    {
                        directories.ChooseTask(child.root, connectionString, dataGridViewReferences);
                        currentTableName = child.root.function_name;
                    };
                }
                else
                {
                    // Если есть подменю, оставляем пустым
                    childMenuItem.Click += (sender, e) => { };
                }

                SetStatus(childMenuItem, child);

                if (child.children != null && child.children.Count > 0)
                {
                    InitializeSubMenu(childMenuItem, child.children);
                }

                parentMenuItem.DropDownItems.Add(childMenuItem);
            }
        }

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

        // выйти
        private void button1_Click(object sender, EventArgs e)
        {
            var Form2 = new Authorise();
            Form2.Show();
            this.Hide();
        }

        // добавить запись
        private void button2_Click(object sender, EventArgs e)
        {
            // Создаем форму для ввода данных
            var addForm = new AddEditForm(currentTableName, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Получаем данные из формы
                var values = new Dictionary<string, object>
            {
                { "name", addForm.RecordName }
            };

                // Добавляем запись
                if (AddRecord(currentTableName, connectionString, values))
                {
                    // Обновляем DataGridView
                    directories.LoadTableData(currentTableName, connectionString, dataGridViewReferences);
                    MessageBox.Show("Запись успешно добавлена!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // удалить запись
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewReferences.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewReferences.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DeleteRecord(currentTableName, connectionString, id))
                    {
                        // Обновляем DataGridView
                        directories.LoadTableData(currentTableName, connectionString, dataGridViewReferences);
                        MessageBox.Show("Запись успешно удалена!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Двойной клик для редактирования
        private void dataGridViewReferences_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewReferences.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                string name = row.Cells["name"].Value.ToString();

                var editForm = new AddEditForm(currentTableName, id, name);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var values = new Dictionary<string, object>
                {
                    { "name", editForm.RecordName }
                };

                    if (UpdateRecord(currentTableName, connectionString, id, values))
                    {
                        directories.LoadTableData(currentTableName, connectionString, dataGridViewReferences);
                        MessageBox.Show("Запись успешно обновлена!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
