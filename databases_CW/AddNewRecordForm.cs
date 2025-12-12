using databases_CW.DB_Read;
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
        //public Dictionary<string, string> FieldValues;
        //private string tableName;
        //private List<string> columns;
        public Dictionary<string, object> FieldValues;
        private List<ColumnMetadata> columnsMetadata;
        string connectionString;

        public AddNewRecordForm(string tableName,
        List<ColumnMetadata> columnsMetadata, string connectionString)
        //public AddNewRecordForm(string tableName, 
        //    List<string> columns)
        {
            InitializeComponent();
            this.columnsMetadata = columnsMetadata;
            this.FieldValues = new Dictionary<string, object>();
            CreateInputFields();
            this.Text = $"Добавить запись в таблицу '{tableName}'";
            this.connectionString = connectionString;
            //this.columns = columns;
            //this.FieldValues = new Dictionary<string, string>();
            //CreateInputFields();
            //this.Text = $"Добавить запись в таблицу '{tableName}'";
        }

        private void CreateInputFields()
        {
            int y = 10;

            foreach (var column in columnsMetadata)
            {
                var label = new Label
                {
                    Text = $"{column.ColumnName} ({column.DataType}):",
                    Location = new Point(10, y),
                    Size = new Size(200, 25),
                    Font = new Font("Arial", 10),
                    Tag = column
                };

                Control inputControl;

                // Выбираем подходящий контрол в зависимости от типа данных
                if (column.DataType.Contains("int") ||
                    column.DataType.Contains("decimal") ||
                    column.DataType.Contains("numeric") ||
                    column.DataType.Contains("real") ||
                    column.DataType.Contains("float"))
                {
                    var numericBox = new NumericUpDown
                    {
                        Name = $"num_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("Arial", 10),
                        DecimalPlaces = column.DataType.Contains("decimal") ||
                                      column.DataType.Contains("numeric") ? 2 : 0,
                        Minimum = decimal.MinValue,
                        Maximum = decimal.MaxValue
                    };

                    // Устанавливаем разумные ограничения для разных типов
                    if (column.DataType == "smallint")
                    {
                        numericBox.Minimum = short.MinValue;
                        numericBox.Maximum = short.MaxValue;
                    }
                    else if (column.DataType == "integer")
                    {
                        numericBox.Minimum = int.MinValue;
                        numericBox.Maximum = int.MaxValue;
                    }

                    inputControl = numericBox;
                }
                else if (column.DataType == "boolean" || column.DataType == "bool")
                {
                    var comboBox = new ComboBox
                    {
                        Name = $"cmb_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("Arial", 10),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    comboBox.Items.AddRange(new object[] { "True", "False" });
                    comboBox.SelectedIndex = 0;

                    inputControl = comboBox;
                }
                else if (column.DataType == "date")
                {
                    var datePicker = new DateTimePicker
                    {
                        Name = $"dtp_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("Arial", 10),
                        Format = DateTimePickerFormat.Short
                    };

                    inputControl = datePicker;
                }
                else if (column.DataType.Contains("timestamp"))
                {
                    var dateTimePicker = new DateTimePicker
                    {
                        Name = $"dtp_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("Arial", 10),
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "dd.MM.yyyy HH:mm:ss",
                        ShowUpDown = true
                    };

                    inputControl = dateTimePicker;
                }
                else
                {
                    var textBox = new TextBox
                    {
                        Name = $"txt_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("Arial", 10),
                        Text = column.IsNullable ? "" : "0"
                    };

                    if (column.MaxLength > 0)
                        textBox.MaxLength = column.MaxLength;

                    inputControl = textBox;
                }

                this.Controls.Add(label);
                this.Controls.Add(inputControl);

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
            this.ClientSize = new Size(500, y + 80);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = button_1;
            this.CancelButton = button_2;



                //int y = 10;

                //foreach (var column in columns)
                //{
                //    var label = new Label
                //    {
                //        Text = $"{column}:",
                //        Location = new Point(10, y),
                //        Size = new Size(150, 25),
                //        Font = new Font("Arial", 10)
                //    };

                //    var textBox = new TextBox
                //    {
                //        Name = $"txt_{column}",
                //        Location = new Point(170, y),
                //        Size = new Size(250, 25),
                //        Tag = column,
                //        Font = new Font("Arial", 10),
                //        Text = "0"
                //    };

                //    this.Controls.Add(label);
                //    this.Controls.Add(textBox);

                //    y += 35;
                //}

                //var button_1 = new Button
                //{
                //    Text = "Добавить",
                //    Location = new Point(120, y + 20),
                //    Size = new Size(100, 35),
                //    DialogResult = DialogResult.OK,
                //    Font = new Font("Arial", 10, FontStyle.Bold)
                //};

                //var button_2 = new Button
                //{
                //    Text = "Отмена",
                //    Location = new Point(250, y + 20),
                //    Size = new Size(100, 35),
                //    DialogResult = DialogResult.Cancel,
                //    Font = new Font("Arial", 10)
                //};

                //button_1.Click += button1_Click;

                //this.Controls.Add(button_1);
                //this.Controls.Add(button_2);

                //this.ClientSize = new Size(450, y + 80);
                //this.StartPosition = FormStartPosition.CenterParent;
                //this.FormBorderStyle = FormBorderStyle.FixedDialog;
                //this.MaximizeBox = false;
                //this.MinimizeBox = false;
                //this.AcceptButton = button_1;
                //this.CancelButton = button_2;
            
        }

        // Согласие
        private void button1_Click(object sender, EventArgs e)
        {
            FieldValues.Clear();
            var metadataService = new DatabaseMetadataService(connectionString);

            foreach (Control control in this.Controls)
            {
                if (control.Tag is ColumnMetadata columnMetadata)
                {
                    object fieldValue = null;

                    if (control is TextBox textBox)
                    {
                        fieldValue = textBox.Text.Trim();
                        fieldValue = metadataService.ConvertToColumnType(columnMetadata.DataType, fieldValue?.ToString());
                    }
                    else if (control is NumericUpDown numericUpDown)
                    {
                        fieldValue = numericUpDown.Value;
                    }
                    else if (control is ComboBox comboBox)
                    {
                        fieldValue = comboBox.SelectedItem?.ToString();
                        fieldValue = metadataService.ConvertToColumnType(columnMetadata.DataType, fieldValue?.ToString());
                    }
                    else if (control is DateTimePicker dateTimePicker)
                    {
                        if (columnMetadata.DataType == "date")
                            fieldValue = DateOnly.FromDateTime(dateTimePicker.Value);
                        else
                            fieldValue = dateTimePicker.Value;
                    }

                    if (fieldValue != null)
                        FieldValues[columnMetadata.ColumnName] = fieldValue;
                }
            }
            DialogResult = DialogResult.OK;
            //FieldValues.Clear();
            //{
            //    FieldValues.Clear();
            //    foreach (Control control in this.Controls)
            //    {
            //        if (control is TextBox textBox && textBox.Tag != null)
            //        {
            //            string fieldName = textBox.Tag.ToString();
            //            string fieldValue = textBox.Text.Trim();

            //            FieldValues[fieldName] = fieldValue;
            //        }
            //    }
            //    DialogResult = DialogResult.OK;
            //}
        }

        private void AddNewRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
