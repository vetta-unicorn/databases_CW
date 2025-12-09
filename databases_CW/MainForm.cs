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
using databases_CW.Instances;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace databases_CW
{
    public partial class MainForm : Form
    {
        private delegate void PrintDelegate(string message);
        private string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";
        private DB_Dicrectories directories = new DB_Dicrectories();
        private string currentTableName;
        private Item currentTable;
        private int currentTableStatus;
        Records record;
        private string currUserPath = "User.json";
        IGetLevel role;
        GetColumns getColumns;
        public MainForm()
        {
            InitializeComponent();
            dataGridViewReferences.CellDoubleClick += dataGridViewReferences_CellDoubleClick;
            SetUser();
            TableMenu table = new TableMenu();
            table.SetMenu();
            InitializeMenuStrip(table.menu);
            menuStrip1.BackColor = Color.FromArgb(224, 255, 255); // .LightCyan
            menuStrip1.Font = new Font("STFangsong", 14f, FontStyle.Regular);
            record = new Records();
            getColumns = new GetColumns(connectionString);

            button2.Visible = false; button2.Enabled = false;
            button3.Visible = false; button3.Enabled = false;
            button4.Visible = false; button4.Enabled = false;
            button5.Visible = false; button5.Enabled = false;

            txtSQL.Visible = false;
        }

        private void ShowTxtSQL()
        {
            dataGridViewReferences.Top = txtSQL.Bottom + 10;
            dataGridViewReferences.Height -= 100;
            txtSQL.Visible = true;
            dataGridViewReferences.BackgroundColor = Color.FromArgb(255, 250, 240);
        }

        private void SetUser()
        {
            string jsonString = File.ReadAllText(currUserPath);
            DB_User currUser = JsonSerializer.Deserialize<DB_User>(jsonString);
            if (currUser.Role == "master") { role = new Master(); }
            else if (currUser.Role == "admin") { role = new Admin(); }
            else if (currUser.Role == "manager") { role = new Manager(); }
            else if (currUser.Role == "commodity_expert") { role = new CommodityExpert(); }
            else if (currUser.Role == "accountant") { role = new Accountant(); }
            else { role = new Role(); }
        }

        public void SetStatus(ToolStripMenuItem menuitem, Tree tree)
        {
            currentTableStatus = role.GetAccessLevel(tree.root.name);

            if (currentTableStatus >= 0)
            {
                menuitem.Visible = true;
                menuitem.Enabled = true;
            }
            else
            {
                menuitem.Visible = false;
                menuitem.Enabled = false;
            }
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
                        MessageBox.Show($"You have called method: {message}");
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
                    InitializeSubMenu(tree, menuItem, tree.children);
                }

                menuStrip1.Items.Add(menuItem);
            }
        }

        private void InitializeSubMenu(Tree root, ToolStripMenuItem parentMenuItem, List<Tree> children)
        {
            foreach (var child in children)
            {
                ToolStripMenuItem childMenuItem = new ToolStripMenuItem(child.root.name);

                if (child.children == null || child.children.Count() == 0)
                {
                    childMenuItem.Click += (sender, e) =>
                    {
                        directories.ChooseTask(child.root, connectionString, dataGridViewReferences);
                        currentTableName = child.root.function_name;
                        currentTable = child.root;
                        currentTableStatus = role.GetAccessLevel(root.root.name);
                        if (currentTableStatus >= 0) // SEL
                        {
                            button4.Visible = true; button4.Enabled = true;
                            button5.Visible = true; button5.Enabled = true;
                            button2.Visible = true; button2.Enabled = false;
                            button3.Visible = true; button3.Enabled = false;
                        }
                        if (currentTableStatus >= 1) // INS
                        {
                            button2.Enabled = true;
                        }
                        if (currentTableStatus == 2) // DEL
                        {
                            button3.Enabled = true;
                        }
                    };
                }
                else
                {
                    childMenuItem.Click += (sender, e) => { };
                }

                SetStatus(childMenuItem, root);

                if (child.children != null && child.children.Count > 0)
                {
                    InitializeSubMenu(root, childMenuItem, child.children);
                }

                parentMenuItem.DropDownItems.Add(childMenuItem);
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
            Dictionary<string, List<string>> allTablesColumns = getColumns.GetAllTablesColumns();

            if (!allTablesColumns.ContainsKey(currentTableName))
            {
                MessageBox.Show($"Не удалось получить информацию о таблице '{currentTableName}'",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> columns = allTablesColumns[currentTableName];

            // фильтр всего кроме id
            var editableColumns = columns
                .Where(c => !c.Equals("id", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (editableColumns.Count == 0)
            {
                MessageBox.Show("В таблице нет редактируемых полей",
                              "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var addForm = new AddNewRecordForm(currentTableName, editableColumns);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var values = new Dictionary<string, object>();

                foreach (var fieldValue in addForm.FieldValues)
                {
                    if (!string.IsNullOrWhiteSpace(fieldValue.Value))
                    {
                        values[fieldValue.Key] = fieldValue.Value;
                    }
                }

                if (values.Count == 0)
                {
                    MessageBox.Show("Необходимо заполнить хотя бы одно поле",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (record.AddRecord(currentTableName, connectionString, values))
                {
                    directories.LoadTableData(currentTableName, connectionString, dataGridViewReferences);
                    MessageBox.Show("Запись успешно добавлена!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось добавить запись", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (record.DeleteRecord(currentTableName, connectionString, id))
                    {
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
            if (currentTableStatus < 2)
            {
                MessageBox.Show("Недоступно редактирование полей");
                return;
            }
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                var row = dataGridViewReferences.Rows[e.RowIndex];
                var column = dataGridViewReferences.Columns[e.ColumnIndex];

                int id = Convert.ToInt32(row.Cells["id"].Value);

                string columnName = column.Name;

                if (columnName.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Поле ID нельзя редактировать", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                object cellValue = row.Cells[columnName].Value;
                string currentValue = cellValue?.ToString() ?? string.Empty;

                string formTitle = $"Редактирование '{columnName}' (ID: {id})";
                var editForm = new AddEditForm(currentTableName, id, currentValue)
                {
                    Text = formTitle
                };

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var values = new Dictionary<string, object>
            {
                { columnName, editForm.RecordName }
            };

                    if (record.UpdateRecord(currentTableName, connectionString, id, values))
                    {
                        directories.LoadTableData(currentTableName, connectionString, dataGridViewReferences);

                        MessageBox.Show($"Поле '{columnName}' успешно обновлено!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить запись", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //фильтрация
        private void button4_Click(object sender, EventArgs e)
        {
            List<string> columns = getColumns.GetTableColumns(currentTableName);

            string currentColumn = "name";
            if (dataGridViewReferences.SelectedCells.Count > 0)
            {
                int columnIndex = dataGridViewReferences.SelectedCells[0].ColumnIndex;
                currentColumn = dataGridViewReferences.Columns[columnIndex].Name;
            }
            using (var form = new AddEditForm(currentTableName, null, "", true))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    record.FilterRecords(currentTableName, connectionString, dataGridViewReferences,
                        form.RecordName, form.ColumnName);
                }
            }
        }

        // сброс фильтра
        private void button5_Click(object sender, EventArgs e)
        {
            directories.ChooseTask(currentTable, connectionString, dataGridViewReferences);
        }

        // сброс DataGridView
        private void button6_Click(object sender, EventArgs e)
        {
            ShowTxtSQL();
            if (dataGridViewReferences.DataSource == null)
            {
                dataGridViewReferences.Rows.Clear();
            }
            else
            {
                dataGridViewReferences.DataSource = null;
            }

            button2.Visible = false; button2.Enabled = false;
            button3.Visible = false; button3.Enabled = false;
            button4.Visible = false; button4.Enabled = false;
            button5.Visible = false; button5.Enabled = false;
        }
    }
}
