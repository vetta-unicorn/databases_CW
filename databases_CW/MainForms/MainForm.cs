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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using databases_CW.DB_Write;
using databases_CW.DB_Read;
using databases_CW.DB_Models;
using databases_CW.Tabs;
using databases_CW.HelpForms;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using databases_CW.Analytics;

namespace databases_CW
{
    public partial class MainForm : Form
    {
        private delegate void PrintDelegate(string message);
        private string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";
        private string userHelpPath = @"C:\Users\lisal\source\repos\databases_CW\databases_CW\Pictures\user_help.html";
        private string aboutPath = @"C:\Users\lisal\source\repos\databases_CW\databases_CW\Pictures\about.html";

        private Panel passPanelContainer;
        System.Windows.Forms.TextBox oldPasswordWin;
        System.Windows.Forms.TextBox newPasswordWin;
        System.Windows.Forms.TextBox repPasswordWin;
        System.Windows.Forms.Button changePass;

        private DB_Dicrectories directories = new DB_Dicrectories();
        private DB_User user;
        private string currentTableName;
        private Item currentTable;
        private int currentTableStatus;
        Records record;
        private string currUserPath = "User.json";
        IGetLevel role;
        GetColumns getColumns;
        Documents docs;
        RefTab refTabs;
        OtherTab otherTab;
        DocSelect docSelect;
        int defaultHeight;
        public MainForm()
        {
            InitializeComponent();
            dataGridViewReferences.CellDoubleClick += dataGridViewReferences_CellDoubleClick;
            user = new DB_User();
            user = user.SetUser(currUserPath);
            role = user.SetRole(currUserPath, user);
            TableMenu table = new TableMenu();
            table.SetMenu();

            docs = new Documents();
            refTabs = new RefTab();
            otherTab = new OtherTab();
            docs.InsertIntoTableMenu(table.menu);
            refTabs.InsertTabs(table.menu);
            otherTab.InsertTabs(table.menu);
            table.menu.Add(new Tree(new Item("Аналитика", "analysis")));
            InitializeMenuStrip(table.menu);

            //menuStrip1.BackColor = Color.FromArgb(224, 255, 255); // .LightCyan
            menuStrip1.BackColor = Color.FromArgb(70, 130, 180); // .LightYellow
            menuStrip1.Font = new Font("STFangsong", 14f, FontStyle.Regular);
            txtSQL.Visible = false;
            txtSQL.Font = new Font(txtSQL.Font.FontFamily, 13f);

            record = new Records();
            getColumns = new GetColumns(connectionString);
            docSelect = new DocSelect(connectionString);
            defaultHeight = dataGridViewReferences.Height;

            button2.Visible = false; button2.Enabled = false;
            button3.Visible = false; button3.Enabled = false;
            button4.Visible = false; button4.Enabled = false;
            button5.Visible = false; button5.Enabled = false;
            button7.Visible = false; button7.Enabled = false;
            button8.Visible = false; button8.Enabled = false;

            txtSQL.Visible = false;
        }

        private void OpenPanel()
        {
            // Скрываем DataGridView
            dataGridViewReferences.Visible = false;

            // панель
            passPanelContainer = new Panel();
            passPanelContainer.Location = dataGridViewReferences.Location;
            passPanelContainer.Width = dataGridViewReferences.Width - 100;
            passPanelContainer.Height = dataGridViewReferences.Height - 100;
            passPanelContainer.Left = dataGridViewReferences.Left + 100;
            passPanelContainer.Top = dataGridViewReferences.Top + 100;
            passPanelContainer.BackColor = Color.FromArgb(211, 211, 211);
            passPanelContainer.Visible = true;

            this.Controls.Add(passPanelContainer);
            passPanelContainer.BringToFront();
        }

        private void CreatePasswordScreen()
        {
            // старый пароль
            oldPasswordWin = new System.Windows.Forms.TextBox();
            oldPasswordWin.Font = new Font("STFangsong", 13f, FontStyle.Regular);
            oldPasswordWin.Size = new Size(500, 60);
            oldPasswordWin.Location = new Point(
                (passPanelContainer.Width - 500) / 2,
                (passPanelContainer.Height - 80) / 2
            );
            oldPasswordWin.PlaceholderText = "Введите старый пароль";
            oldPasswordWin.PasswordChar = '*';

            // новый пароль
            newPasswordWin = new System.Windows.Forms.TextBox();
            newPasswordWin.Font = new Font("STFangsong", 13f, FontStyle.Regular);
            newPasswordWin.Size = new Size(500, 60);
            newPasswordWin.Location = new Point(
                (passPanelContainer.Width - 500) / 2,
                oldPasswordWin.Bottom + 10
            );

            newPasswordWin.PlaceholderText = "Введите новый пароль";
            newPasswordWin.PasswordChar = '*';

            // повтор пароля
            repPasswordWin = new System.Windows.Forms.TextBox();
            repPasswordWin.Font = new Font("STFangsong", 13f, FontStyle.Regular);
            repPasswordWin.Size = new Size(500, 60);
            repPasswordWin.Location = new Point(
                (passPanelContainer.Width - 500) / 2,
                newPasswordWin.Bottom + 10
            );

            repPasswordWin.PlaceholderText = "Введите новый пароль повторно";
            repPasswordWin.PasswordChar = '*';

            // кнопка
            changePass = new System.Windows.Forms.Button();
            changePass.Text = "Сменить пароль";
            changePass.Font = new Font("STFangsong", 13f, FontStyle.Regular);
            changePass.BackColor = Color.FromArgb(255, 255, 255);
            changePass.Size = new Size(500, 40);
            changePass.Location = new Point(
                (passPanelContainer.Width - 500) / 2,
                repPasswordWin.Bottom + 10
            );
            changePass.Click += changePass_Click;

            passPanelContainer.Controls.Add(oldPasswordWin);
            passPanelContainer.Controls.Add(newPasswordWin);
            passPanelContainer.Controls.Add(repPasswordWin);
            passPanelContainer.Controls.Add(changePass);
        }

        private void HideAndDisposePasswordControls()
        {
            if (passPanelContainer != null)
            {
                passPanelContainer.Visible = false;
                if (oldPasswordWin != null)
                {
                    oldPasswordWin.Dispose();
                    oldPasswordWin = null;
                }
                if (newPasswordWin != null)
                {
                    newPasswordWin.Dispose();
                    newPasswordWin = null;
                }
                if (repPasswordWin != null)
                {
                    repPasswordWin.Dispose();
                    repPasswordWin = null;
                }
                if (changePass != null)
                {
                    changePass.Dispose();
                    changePass = null;
                }
                passPanelContainer.Controls.Clear();
            }
        }

        private void changePass_Click(object sender, EventArgs e)
        {
            WriteNewPassword writeNewPass = new WriteNewPassword();
            try
            {
                bool flag = user.CheckChangePassword(
                    oldPasswordWin.Text, newPasswordWin.Text, repPasswordWin.Text);
                if (flag)
                {
                    if (writeNewPass.ChangeUserPassword(user, newPasswordWin.Text, connectionString))
                    {
                        MessageBox.Show("Смена пароля выполнена успешно!");
                    }
                    else { MessageBox.Show("Смена пароля не выполнена..."); }
                }
                else { throw new Exception("Введены неверные данные!"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Вызвано исключение: {ex}");
            }
        }

        private void SwapButtons(System.Windows.Forms.Button buttonToHide, System.Windows.Forms.Button buttonToShow)
        {
            Control parent = buttonToHide.Parent;

            buttonToShow.Location = buttonToHide.Location;
            buttonToShow.Size = buttonToHide.Size;
            buttonToShow.Visible = true;

            buttonToHide.Visible = false;

            if (buttonToShow.Parent != parent)
            {
                if (buttonToShow.Parent != null)
                {
                    buttonToShow.Parent.Controls.Remove(buttonToShow);
                }
                parent.Controls.Add(buttonToShow);
            }
            buttonToShow.BringToFront();
        }

        private void ShowTxtSQL(bool Flag) // true - открыть txtSQL, false - закрыть txtSQL
        {
            if (Flag)
            {
                dataGridViewReferences.Top = txtSQL.Bottom + 10;
                dataGridViewReferences.Height = defaultHeight - 100;
                txtSQL.Visible = true;
            }
            else
            {
                dataGridViewReferences.Top = txtSQL.Top;
                dataGridViewReferences.Height = defaultHeight;
                txtSQL.Visible = false;
            }
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

                SetStatus(menuItem, tree);

                if (tree.root.name == "Аналитика")
                {
                    menuItem.Click += (sender, e) =>
                    {
                        GoToAnalytics();
                    };
                }

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
                        ClearGaraGridView();
                        HideAndDisposePasswordControls();
                        if (root.root.name == "Документы")
                        {
                            txtSQL.Text = child.root.function_name;
                            dataGridViewReferences.Visible = true;
                            ShowTxtSQL(true);
                            SwapButtons(button2, button7);
                            SwapButtons(button3, button8);
                            button7.Visible = true; button7.Enabled = true;
                            button8.Visible = true; button8.Enabled = true;
                            button4.Visible = true; button4.Enabled = false; // пока что false
                            button5.Visible = true; button5.Enabled = false;
                        }
                        else if (root.root.name == "Справка")
                        {
                            button2.Visible = false; button3.Visible = false;
                            button4.Visible = false; button5.Visible = false;
                            button7.Visible = false; button8.Visible = false;
                            string tmpPath = "";
                            if (child.root.name == "Руководство пользователя") { tmpPath = userHelpPath; }
                            else if (child.root.name == "О программе") { tmpPath = aboutPath; }
                            using (var helper = new ShowHelpTabForm(tmpPath))
                            {
                                helper.ShowDialog();
                            }
                        }
                        else if (root.root.name == "Разное")
                        {
                            ShowTxtSQL(false);
                            OpenPanel();
                            if (child.root.name == "Смена пароля") { CreatePasswordScreen(); }
                        }
                        else
                        {
                            ShowTxtSQL(false);
                            button7.Visible = false; button7.Enabled = false;
                            button8.Visible = false; button8.Enabled = false;

                            directories.LoadAndReplaceForeignKeys(child.root.function_name,
                                connectionString, dataGridViewReferences);
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
            var metadataService = new DatabaseMetadataService(connectionString);
            var columnsMetadata = metadataService.GetTableColumns(currentTableName);

            var editableColumns = columnsMetadata
                .Where(c => !c.ColumnName.Equals("id", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (editableColumns.Count == 0)
            {
                MessageBox.Show("В таблице нет редактируемых полей",
                              "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var addForm = new AddNewRecordForm(currentTableName, editableColumns, connectionString);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var values = new Dictionary<string, object>();

                foreach (var fieldValue in addForm.FieldValues)
                {
                    if (fieldValue.Value != null &&
                        !(fieldValue.Value is DBNull) &&
                        !string.IsNullOrWhiteSpace(fieldValue.Value.ToString()))
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
                    directories.LoadAndReplaceForeignKeys(currentTableName, connectionString,
                        dataGridViewReferences);
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
            directories.LoadTableData(currentTable.function_name, connectionString, dataGridViewReferences);
        }

        // очистить панель
        private void ClearGaraGridView()
        {
            if (dataGridViewReferences.DataSource == null)
            {
                dataGridViewReferences.Rows.Clear();
            }
            else
            {
                dataGridViewReferences.DataSource = null;
            }
        }

        // сброс DataGridView - закрыть вкладку
        private void button6_Click(object sender, EventArgs e)
        {
            ClearGaraGridView();
            button2.Visible = false; button2.Enabled = false;
            button3.Visible = false; button3.Enabled = false;
            button4.Visible = false; button4.Enabled = false;
            button5.Visible = false; button5.Enabled = false;
            button7.Visible = false; button7.Enabled = false;
            button8.Visible = false; button8.Enabled = false;

            if (txtSQL.Visible == true)
            {
                ShowTxtSQL(false);
            }

            HideAndDisposePasswordControls();
        }

        // Выполнить запрос
        private void button7_Click(object sender, EventArgs e)
        {
            docSelect.DoSelect(dataGridViewReferences, txtSQL.Text);
        }

        // скачать файл
        private void button8_Click(object sender, EventArgs e)
        {
            var downloadForm = new DownloadFileForm(dataGridViewReferences);
            if (downloadForm.ShowDialog() == DialogResult.OK)
            {
                downloadForm.SaveDataToFile();
            }
        }

        // открыть аналитику
        private void GoToAnalytics()
        {
            var analyticsForm = new AnalyticsDashboardForm();
            analyticsForm.Show();
            this.Close();
        }
    }
}
