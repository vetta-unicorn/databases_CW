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
    public partial class AddNewRecordForm : Form
    {
        public Dictionary<string, string> FieldValues;
        private string tableName;
        private List<string> columns;

        public AddNewRecordForm(string tableName, List<string> columns)
        {
            InitializeComponent();
            this.columns = columns;
            this.FieldValues = new Dictionary<string, string>();
            CreateInputFields();
            this.Text = $"Добавить запись в таблицу '{tableName}'";
        }

        private List<string> GetTableColumns()
        {
            var columns = new List<string>();
            switch (tableName)
            {
                case "books":
                    columns = new List<string> { "title", "author", "price", "quantity" };
                    break;
                case "orders":
                    columns = new List<string> { "customer_name", "order_date", "total_amount" };
                    break;
                default:
                    columns = new List<string> { "name" };
                    break;
            }

            return columns;
        }

        private void CreateInputFields()
        {
            int y = 10;

            foreach (var column in columns)
            {
                var label = new Label
                {
                    Text = $"{column}:",
                    Location = new Point(10, y),
                    Size = new Size(150, 25),
                    Font = new Font("Arial", 10)
                };

                var textBox = new TextBox
                {
                    Name = $"txt_{column}",
                    Location = new Point(170, y),
                    Size = new Size(250, 25),
                    Tag = column,
                    Font = new Font("Arial", 10)
                };

                this.Controls.Add(label);
                this.Controls.Add(textBox);

                y += 35;
            }

            var button_1 = new Button
            {
                Text = "Добавить",
                Location = new Point(120, y + 20),
                Size = new Size(100, 35),
                DialogResult = DialogResult.OK,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            var button_2 = new Button
            {
                Text = "Отмена",
                Location = new Point(250, y + 20),
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel,
                Font = new Font("Arial", 10)
            };

            button_1.Click += button1_Click;

            this.Controls.Add(button_1);
            this.Controls.Add(button_2);

            this.ClientSize = new Size(450, y + 80);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = button_1;
            this.CancelButton = button_2;
        }

        // Согласие
        private void button1_Click(object sender, EventArgs e)
        {
            FieldValues.Clear();
            {
                FieldValues.Clear();
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox textBox && textBox.Tag != null)
                    {
                        string fieldName = textBox.Tag.ToString();
                        string fieldValue = textBox.Text.Trim();

                        FieldValues[fieldName] = fieldValue;
                    }
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void AddNewRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
