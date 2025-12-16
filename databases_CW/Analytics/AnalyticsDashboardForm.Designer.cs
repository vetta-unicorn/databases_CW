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
            pictureBox1 = new PictureBox();
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
            panel5 = new Panel();
            pictureBox3 = new PictureBox();
            panel6 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel6.SuspendLayout();
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
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel6);
            panel1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1376, 685);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(61, 440);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 209);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(273, 177);
            button2.Name = "button2";
            button2.Size = new Size(236, 37);
            button2.TabIndex = 5;
            button2.Text = "Экспорт графиков";
            button2.UseVisualStyleBackColor = false;
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
            label3.BackColor = SystemColors.GradientInactiveCaption;
            label3.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(104, 12);
            label3.Name = "label3";
            label3.Size = new Size(206, 26);
            label3.TabIndex = 1;
            label3.Text = "Заказы в этом году";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(12, 177);
            button1.Name = "button1";
            button1.Size = new Size(236, 37);
            button1.TabIndex = 4;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = false;
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
            label2.BackColor = SystemColors.GradientInactiveCaption;
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
            label1.BackColor = SystemColors.GradientInactiveCaption;
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
            pictureBox2.Location = new Point(16, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(330, 179);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlLightLight;
            panel5.Controls.Add(pictureBox2);
            panel5.Location = new Point(967, 440);
            panel5.Name = "panel5";
            panel5.Size = new Size(363, 211);
            panel5.TabIndex = 9;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(94, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(331, 147);
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ButtonHighlight;
            panel6.Controls.Add(pictureBox3);
            panel6.Controls.Add(button2);
            panel6.Controls.Add(button1);
            panel6.Location = new Point(400, 428);
            panel6.Name = "panel6";
            panel6.Size = new Size(522, 237);
            panel6.TabIndex = 11;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel6.ResumeLayout(false);
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
        private Panel panel5;
        private Panel panel6;
        private PictureBox pictureBox3;
    }
}