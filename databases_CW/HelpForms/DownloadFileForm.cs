using databases_CW.DB_Write;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databases_CW
{
    public partial class DownloadFileForm : Form
    {
        DataGridView dataGrid;
        public string fileName;
        public string pathName;
        public DownloadFileForm(DataGridView dataGrid)
        {
            InitializeComponent();
            this.dataGrid = dataGrid;
            fileName = "NewSelect.html";
            pathName = @"C:\Users\lisal\Downloads";
            txtName.Text = fileName;
            txtPath.Text = pathName;
        }

        // сохранить
        private void DwldButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Поле 'Название' не может быть пустым", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("Поле 'Путь к файлу' не может быть пустым", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fileName = txtName.Text;
            pathName = txtPath.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        // отмена
        private void CnclButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string CheckFileName()
        {
            string fileName = txtName.Text;
            if (fileName.Contains("."))
            {
                string[] tmp = fileName.Split(".");
                if (tmp.Last() == "html") { return fileName; }
            }
            return fileName + ".html";
        }

        // сохранение в html файл
        public void SaveDataToFile()
        {
            string fullPath = Path.Combine(pathName, CheckFileName());
            if (File.Exists(fullPath))
            {
                MessageBox.Show($"Путь {fullPath} уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DataTable dt = new DataTable();
                if (dataGrid.DataSource != null)
                {
                    dt = ((DataTable)dataGrid.DataSource).Copy();
                }
                else
                {
                    foreach (DataGridViewColumn column in dataGrid.Columns)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (!row.IsNewRow) 
                        {
                            DataRow dataRow = dt.NewRow();
                            for (int i = 0; i < dataGrid.Columns.Count; i++)
                            {
                                dataRow[i] = row.Cells[i].Value ?? DBNull.Value;
                            }
                            dt.Rows.Add(dataRow);
                        }
                    }
                }

                WorkerHTML.ExportToHtml(dt, fullPath);

                MessageBox.Show($"Файл успешно сохранен: {fullPath}", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
