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
            panel4 = new Panel();
            formsPlot3 = new ScottPlot.WinForms.FormsPlot();
            label3 = new Label();
            panel3 = new Panel();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            pictureBox2 = new PictureBox();
            panel6 = new Panel();
            pictureBox3 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            panel7 = new Panel();
            formsPlot4 = new ScottPlot.WinForms.FormsPlot();
            label4 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(50, 57);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(339, 295);
            formsPlot1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(panel7);
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
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.Controls.Add(formsPlot3);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(916, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(414, 376);
            panel4.TabIndex = 4;
            // 
            // formsPlot3
            // 
            formsPlot3.DisplayScale = 1.25F;
            formsPlot3.Location = new Point(26, 46);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(339, 306);
            formsPlot3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientInactiveCaption;
            label3.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(87, 13);
            label3.Name = "label3";
            label3.Size = new Size(206, 26);
            label3.TabIndex = 1;
            label3.Text = "Заказы в этом году";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(formsPlot2);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(37, 13);
            panel3.Name = "panel3";
            panel3.Size = new Size(357, 325);
            panel3.TabIndex = 3;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(47, 46);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(272, 244);
            formsPlot2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientInactiveCaption;
            label2.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(47, 13);
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
            panel2.Location = new Point(430, 13);
            panel2.Name = "panel2";
            panel2.Size = new Size(452, 376);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Font = new Font("STFangsong", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(38, 17);
            label1.Name = "label1";
            label1.Size = new Size(370, 22);
            label1.TabIndex = 1;
            label1.Text = "Количество проданных книг по темам";
            label1.Click += label1_Click;
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
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(16, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(330, 179);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ButtonHighlight;
            panel6.Controls.Add(pictureBox3);
            panel6.Controls.Add(button2);
            panel6.Controls.Add(button1);
            panel6.Location = new Point(430, 428);
            panel6.Name = "panel6";
            panel6.Size = new Size(522, 237);
            panel6.TabIndex = 11;
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
            // panel7
            // 
            panel7.BackColor = SystemColors.ControlLightLight;
            panel7.Controls.Add(formsPlot4);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(27, 362);
            panel7.Name = "panel7";
            panel7.Size = new Size(367, 303);
            panel7.TabIndex = 3;
            // 
            // formsPlot4
            // 
            formsPlot4.DisplayScale = 1.25F;
            formsPlot4.Location = new Point(37, 45);
            formsPlot4.Name = "formsPlot4";
            formsPlot4.Size = new Size(268, 244);
            formsPlot4.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.GradientInactiveCaption;
            label4.Font = new Font("STFangsong", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(47, 20);
            label4.Name = "label4";
            label4.Size = new Size(283, 22);
            label4.TabIndex = 1;
            label4.Text = "Книги с категоризацией цены";
            // 
            // AnalyticsDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 758);
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
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
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
        private PictureBox pictureBox2;
        private Panel panel5;
        private Panel panel6;
        private PictureBox pictureBox3;
        private Panel panel7;
        private ScottPlot.WinForms.FormsPlot formsPlot4;
        private Label label4;
    }
}