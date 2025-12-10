namespace databases_CW
{
    partial class DownloadFileForm
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
            DwldButton = new Button();
            CnclButton = new Button();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            txtPath = new TextBox();
            SuspendLayout();
            // 
            // DwldButton
            // 
            DwldButton.Font = new Font("STFangsong", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 204);
            DwldButton.Location = new Point(267, 180);
            DwldButton.Name = "DwldButton";
            DwldButton.Size = new Size(104, 36);
            DwldButton.TabIndex = 0;
            DwldButton.Text = "Скачать";
            DwldButton.UseVisualStyleBackColor = true;
            DwldButton.Click += DwldButton_Click;
            // 
            // CnclButton
            // 
            CnclButton.Font = new Font("STFangsong", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CnclButton.Location = new Point(96, 180);
            CnclButton.Name = "CnclButton";
            CnclButton.Size = new Size(104, 36);
            CnclButton.TabIndex = 1;
            CnclButton.Text = "Отмена";
            CnclButton.UseVisualStyleBackColor = true;
            CnclButton.Click += CnclButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("STFangsong", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(64, 52);
            label1.Name = "label1";
            label1.Size = new Size(117, 26);
            label1.TabIndex = 2;
            label1.Text = "Имя файла";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("STFangsong", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(41, 103);
            label2.Name = "label2";
            label2.Size = new Size(140, 26);
            label2.TabIndex = 3;
            label2.Text = "Путь к файлу";
            // 
            // txtName
            // 
            txtName.Location = new Point(224, 52);
            txtName.Name = "txtName";
            txtName.Size = new Size(147, 27);
            txtName.TabIndex = 4;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(224, 103);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(147, 27);
            txtPath.TabIndex = 5;
            // 
            // DownloadFileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 256);
            Controls.Add(txtPath);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CnclButton);
            Controls.Add(DwldButton);
            Name = "DownloadFileForm";
            Text = "DownloadFileForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DwldButton;
        private Button CnclButton;
        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtPath;
    }
}