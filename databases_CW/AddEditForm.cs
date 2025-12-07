using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace databases_CW
{
    public partial class AddEditForm : Form
    {
        public string RecordName;
        private bool isEditMode;
        private bool idSearchMode;
        private string tableName;
        public AddEditForm(string tableName, int? id = null, string currentName = "",
            bool isSearchMode = false)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.isEditMode = id.HasValue;

            if (isSearchMode)
            {
                this.Text = $"Поиск в {tableName}";
                button1.Text = "Найти";
            }

            else if (isEditMode)
            {
                this.Text = $"Редактирование {tableName}";
                txtName.Text = currentName;
            }
            else
            {
                this.Text = $"Добавление {tableName}";
            }
        }

        // сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Поле 'Название' не может быть пустым", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RecordName = txtName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        // удалить
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
