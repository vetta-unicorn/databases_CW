namespace databases_CW.Analytics
{
    partial class AnalyticsDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyticsDashboardForm));
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            panel1 = new Panel();
            button2 = new Button();
            panel4 = new Panel();
            formsPlot3 = new ScottPlot.WinForms.FormsPlot();
            label3 = new Label();
            button1 = new Button();
            panel3 = new Panel();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(47, 58);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(314, 279);
            formsPlot1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1376, 685);
            panel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(659, 532);
            button2.Name = "button2";
            button2.Size = new Size(236, 37);
            button2.TabIndex = 5;
            button2.Text = "Экспорт графиков";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.Controls.Add(formsPlot3);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(896, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(417, 376);
            panel4.TabIndex = 4;
            // 
            // formsPlot3
            // 
            formsPlot3.DisplayScale = 1.25F;
            formsPlot3.Location = new Point(47, 58);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(315, 279);
            formsPlot3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PapayaWhip;
            label3.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(104, 12);
            label3.Name = "label3";
            label3.Size = new Size(206, 26);
            label3.TabIndex = 1;
            label3.Text = "Заказы в этом году";
            // 
            // button1
            // 
            button1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(407, 532);
            button1.Name = "button1";
            button1.Size = new Size(236, 37);
            button1.TabIndex = 4;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(formsPlot2);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(458, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(419, 376);
            panel3.TabIndex = 3;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(47, 58);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(320, 279);
            formsPlot2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PapayaWhip;
            label2.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(89, 12);
            label2.Name = "label2";
            label2.Size = new Size(256, 26);
            label2.TabIndex = 1;
            label2.Text = "Сотрудники в городах";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(formsPlot1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(14, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(427, 376);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PapayaWhip;
            label1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(422, 26);
            label1.TabIndex = 1;
            label1.Text = "Количество проданных книг по темам";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1000, 445);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(274, 190);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(61, 426);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 209);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // AnalyticsDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 689);
            Controls.Add(panel1);
            Name = "AnalyticsDashboardForm";
            Text = "Аналитика";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Label label2;
        private Button button1;
        private Panel panel4;
        private ScottPlot.WinForms.FormsPlot formsPlot3;
        private Label label3;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}