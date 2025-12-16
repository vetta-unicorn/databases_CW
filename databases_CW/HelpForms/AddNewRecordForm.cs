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
        public Dictionary<string, object> FieldValues;
        private List<ColumnMetadata> columnsMetadata;
        string connectionString;

        public AddNewRecordForm(string tableName,
        List<ColumnMetadata> columnsMetadata, string connectionString)
        {
            InitializeComponent();
            this.columnsMetadata = columnsMetadata;
            this.FieldValues = new Dictionary<string, object>();
            CreateInputFields();
            this.Text = $"Добавить запись в таблицу '{tableName}'";
            this.connectionString = connectionString;
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
                    Font = new Font("STFangsong", 14f, FontStyle.Regular),
                    Tag = column
                };

                Control inputControl;

                // элемент управления -> тип данных
                if (column.DataType.Contains("int") ||
                    column.DataType.Contains("decimal") ||
                    column.DataType.Contains("numeric") ||
                    column.DataType.Contains("real") ||
                    column.DataType.Contains("float"))
                {
                    var numericBox = new NumericUpDown // числовой бокс
                    {
                        Name = $"num_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("STFangsong", 12f, FontStyle.Regular),
                        DecimalPlaces = column.DataType.Contains("decimal") ||
                                      column.DataType.Contains("numeric") ? 2 : 0,
                        Minimum = decimal.MinValue,
                        Maximum = decimal.MaxValue
                    };

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
                    numericBox.Value = 0;

                    inputControl = numericBox;
                }
                else if (column.DataType == "boolean"
                    || column.DataType == "bool") // логический бокс
                {
                    var comboBox = new ComboBox
                    {
                        Name = $"cmb_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("STFangsong", 12f, FontStyle.Regular),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    comboBox.Items.AddRange(new object[] { "True", "False" });

                    comboBox.SelectedItem = "True";

                    inputControl = comboBox;
                }
                else if (column.DataType == "date") // бокс с датой (календарик)
                {
                    var datePicker = new DateTimePicker
                    {
                        Name = $"dtp_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("STFangsong", 12f, FontStyle.Regular),
                        Format = DateTimePickerFormat.Short
                    };

                    // сегодняшняя дата
                    datePicker.Value = DateTime.Today;

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
                        Font = new Font("STFangsong", 12f, FontStyle.Regular),
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "dd.MM.yyyy HH:mm:ss",
                        ShowUpDown = true
                    };

                    // timestamp: текущая дата и время
                    dateTimePicker.Value = DateTime.Now;

                    inputControl = dateTimePicker;
                }
                else // текстовые типы 
                {
                    var textBox = new TextBox
                    {
                        Name = $"txt_{column.ColumnName}",
                        Location = new Point(220, y),
                        Size = new Size(250, 25),
                        Tag = column,
                        Font = new Font("STFangsong", 12f, FontStyle.Regular),
                        Text = "new"
                    };

                    if (column.MaxLength > 0)
                        textBox.MaxLength = column.MaxLength;

                    inputControl = textBox;
                }

                if (column.IsNullable)
                {
                    var nullCheckBox = new CheckBox
                    {
                        Text = "NULL",
                        Location = new Point(480, y),
                        Size = new Size(60, 25),
                        Font = new Font("STFangsong", 10f, FontStyle.Regular),
                        Tag = inputControl 
                    };

                    nullCheckBox.CheckedChanged += (s, e) =>
                    {
                        var checkBox = s as CheckBox;
                        var mainControl = checkBox.Tag as Control;
                        mainControl.Enabled = !checkBox.Checked;

                        if (mainControl is TextBox textBox)
                        {
                            textBox.Text = checkBox.Checked ? "" : "new";
                        }
                        else if (mainControl is NumericUpDown numericBox)
                        {
                            numericBox.Value = checkBox.Checked ? 0 : 0;
                        }
                        else if (mainControl is ComboBox comboBox)
                        {
                            comboBox.SelectedItem = checkBox.Checked ? null : "True";
                        }
                        else if (mainControl is DateTimePicker datePicker)
                        {
                            datePicker.Value = checkBox.Checked ? DateTime.Today : DateTime.Today;
                        }
                    };

                    this.Controls.Add(nullCheckBox);
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
                Font = new Font("STFangsong", 14f, FontStyle.Regular)
            };

            var button_2 = new Button
            {
                Text = "Отмена",
                Location = new Point(250, y + 20),
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel,
                Font = new Font("STFangsong", 14f, FontStyle.Regular)
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
        }

        // Добавить запись
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
        }

        private void AddNewRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
