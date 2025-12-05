namespace databases_CW
{
    partial class Authorise
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorise));
            button1 = new Button();
            panel1 = new Panel();
            panel5 = new Panel();
            label5 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(603, 47);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Вход";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 502);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonHighlight;
            panel5.Controls.Add(button2);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(button1);
            panel5.Controls.Add(textBox1);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(28, 299);
            panel5.Name = "panel5";
            panel5.Size = new Size(855, 152);
            panel5.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("STFangsong", 11.999999F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.Location = new Point(69, 106);
            label5.Name = "label5";
            label5.Size = new Size(72, 22);
            label5.TabIndex = 6;
            label5.Text = "Пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("STFangsong", 11.999999F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label4.Location = new Point(69, 54);
            label4.Name = "label4";
            label4.Size = new Size(159, 22);
            label4.TabIndex = 3;
            label4.Text = "Имя пользователя";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(258, 106);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(299, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(258, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 27);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(224, 12);
            label3.Name = "label3";
            label3.Size = new Size(382, 26);
            label3.TabIndex = 3;
            label3.Text = "Введите имя пользователя и пароль";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(28, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(855, 227);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(label1);
            panel4.Location = new Point(235, 36);
            panel4.Name = "panel4";
            panel4.Size = new Size(583, 63);
            panel4.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("STFangsong", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(133, 18);
            label1.Name = "label1";
            label1.Size = new Size(307, 31);
            label1.TabIndex = 0;
            label1.Text = "АИС Книжный магазин";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Info;
            panel3.Controls.Add(label2);
            panel3.Location = new Point(235, 123);
            panel3.Name = "panel3";
            panel3.Size = new Size(583, 63);
            panel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("STFangsong", 11.999999F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.Location = new Point(463, 29);
            label2.Name = "label2";
            label2.Size = new Size(107, 22);
            label2.TabIndex = 2;
            label2.Text = "Версия 1.0.0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(196, 172);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(603, 105);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "Очистить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Authorise
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 499);
            Controls.Add(panel1);
            Name = "Authorise";
            Text = "Authorisation";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Label label1;
        private Panel panel3;
        private Label label2;
        private Panel panel5;
        private TextBox textBox1;
        private Label label3;
        private Label label5;
        private Label label4;
        private TextBox textBox2;
        private Button button2;
    }
}
