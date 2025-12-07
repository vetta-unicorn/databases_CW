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
        private Item currentTable;
        Records record;
        public MainForm()
        {
            InitializeComponent();
            dataGridViewReferences.CellDoubleClick += dataGridViewReferences_CellDoubleClick;
            TableMenu table = new TableMenu();
            table.SetMenu();
            InitializeMenuStrip(table.menu);
            menuStrip1.BackColor = Color.FromArgb(224, 255, 255);
            menuStrip1.Font = new Font("STFangsong", 12f, FontStyle.Regular);
            record = new Records();

            button2.Visible = false; button2.Enabled = false;
            button3.Visible = false; button3.Enabled = false;
            button4.Visible = false; button4.Enabled = false;
            button5.Visible = false; button5.Enabled = false;
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
                        currentTable = child.root;
                        button3.Visible = true; button3.Enabled = true;
                        button2.Visible = true; button2.Enabled = true;
                        button4.Visible = true; button4.Enabled = true;
                        button5.Visible = true; button5.Enabled = true;
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
                if (record.AddRecord(currentTableName, connectionString, values))
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
                    if (record.DeleteRecord(currentTableName, connectionString, id))
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
            try
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

                        if (record.UpdateRecord(currentTableName, connectionString, id, values))
                        {
                            directories.LoadTableData(currentTableName, connectionString, dataGridViewReferences);
                            MessageBox.Show("Запись успешно обновлена!", "Успех",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex}");
            }

        }

        // фильтрация
        private void button4_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditForm(currentTableName, null, "", true))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    record.FilterRecords(currentTableName, connectionString, dataGridViewReferences, form.RecordName);
                }
            }
        }

        // сброс фильтра
        private void button5_Click(object sender, EventArgs e)
        {
            directories.ChooseTask(currentTable, connectionString, dataGridViewReferences);
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
