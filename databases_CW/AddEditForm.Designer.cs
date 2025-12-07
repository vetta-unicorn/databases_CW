namespace databases_CW
{
    partial class AddEditForm
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
            txtName = new TextBox();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(49, 142);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 0;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(49, 78);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // button2
            // 
            button2.Font = new Font("STFangsong", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(49, 188);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(49, 31);
            label1.Name = "label1";
            label1.Size = new Size(155, 26);
            label1.TabIndex = 3;
            label1.Text = "Введите name";
            // 
            // AddEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 288);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(txtName);
            Controls.Add(button1);
            Name = "AddEditForm";
            Text = "AddEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtName;
        private Button button2;
        private Label label1;
    }
}