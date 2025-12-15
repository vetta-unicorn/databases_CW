namespace databases_CW
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            dataGridViewReferences = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            txtSQL = new RichTextBox();
            panel1 = new Panel();
            button8 = new Button();
            button7 = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReferences).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightCyan;
            button1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(594, 598);
            button1.Name = "button1";
            button1.Size = new Size(194, 37);
            button1.TabIndex = 0;
            button1.Text = "Выйти";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1415, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // dataGridViewReferences
            // 
            dataGridViewReferences.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewReferences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReferences.Location = new Point(28, 41);
            dataGridViewReferences.Name = "dataGridViewReferences";
            dataGridViewReferences.RowHeadersWidth = 51;
            dataGridViewReferences.Size = new Size(1296, 459);
            dataGridViewReferences.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(340, 547);
            button2.Name = "button2";
            button2.Size = new Size(199, 37);
            button2.TabIndex = 3;
            button2.Text = "Добавить запись";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonHighlight;
            button3.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(340, 598);
            button3.Name = "button3";
            button3.Size = new Size(199, 37);
            button3.TabIndex = 4;
            button3.Text = "Удалить запись";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonHighlight;
            button4.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(833, 547);
            button4.Name = "button4";
            button4.Size = new Size(194, 37);
            button4.TabIndex = 5;
            button4.Text = "Фильтр";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ButtonHighlight;
            button5.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button5.Location = new Point(833, 598);
            button5.Name = "button5";
            button5.Size = new Size(194, 37);
            button5.TabIndex = 6;
            button5.Text = "Сброс фильтра";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.LightCyan;
            button6.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button6.Location = new Point(594, 547);
            button6.Name = "button6";
            button6.Size = new Size(194, 37);
            button6.TabIndex = 7;
            button6.Text = "Закрыть вкладку";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // txtSQL
            // 
            txtSQL.Location = new Point(28, 41);
            txtSQL.Name = "txtSQL";
            txtSQL.Size = new Size(1296, 93);
            txtSQL.TabIndex = 8;
            txtSQL.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(txtSQL);
            panel1.Controls.Add(dataGridViewReferences);
            panel1.Location = new Point(27, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1355, 618);
            panel1.TabIndex = 9;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.ButtonHighlight;
            button8.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button8.Location = new Point(1028, 571);
            button8.Name = "button8";
            button8.Size = new Size(209, 37);
            button8.TabIndex = 10;
            button8.Text = "Скачать файл";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ButtonHighlight;
            button7.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button7.Location = new Point(1028, 520);
            button7.Name = "button7";
            button7.Size = new Size(209, 37);
            button7.TabIndex = 9;
            button7.Text = "Выполнить запрос";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button9
            // 
            button9.Location = new Point(158, 546);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 11;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1415, 674);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "АИС Книжный магазин";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReferences).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private DataGridView dataGridViewReferences;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private RichTextBox richTextBox1;
        private RichTextBox txtSQL;
        private Panel panel1;
        private Button button8;
        private Button button7;
        private Button button9;
    }
}