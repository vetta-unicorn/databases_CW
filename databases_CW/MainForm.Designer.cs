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
            ((System.ComponentModel.ISupportInitialize)dataGridViewReferences).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(12, 378);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Выйти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // dataGridViewReferences
            // 
            dataGridViewReferences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReferences.Location = new Point(12, 81);
            dataGridViewReferences.Name = "dataGridViewReferences";
            dataGridViewReferences.RowHeadersWidth = 51;
            dataGridViewReferences.Size = new Size(776, 275);
            dataGridViewReferences.TabIndex = 2;
            // 
            // button2
            // 
            button2.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(132, 378);
            button2.Name = "button2";
            button2.Size = new Size(170, 29);
            button2.TabIndex = 3;
            button2.Text = "Добавить запись";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(132, 424);
            button3.Name = "button3";
            button3.Size = new Size(170, 29);
            button3.TabIndex = 4;
            button3.Text = "Удалить запись";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(320, 378);
            button4.Name = "button4";
            button4.Size = new Size(170, 29);
            button4.TabIndex = 5;
            button4.Text = "Фильтр";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button5.Location = new Point(320, 424);
            button5.Name = "button5";
            button5.Size = new Size(170, 29);
            button5.TabIndex = 6;
            button5.Text = "Сброс фильтра";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button6.Location = new Point(12, 424);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 7;
            button6.Text = "Закрыть";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 534);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridViewReferences);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReferences).EndInit();
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
    }
}