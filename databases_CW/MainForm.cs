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

namespace databases_CW
{
    public partial class MainForm : Form
    {
        private delegate void PrintDelegate(string message);
        private string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";
        public MainForm()
        {
            InitializeComponent();
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
                        LoadTableData(child.root.function_name);
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

        private void LoadTableData(string tableName)
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

                        // Опционально: добавить заголовок
                        // this.Text = $"Справочник: {tableName}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // выйти
        private void button1_Click(object sender, EventArgs e)
        {
            var Form2 = new Authorise();
            Form2.Show();
            this.Hide();
        }


    }
}
