namespace ManejadorBdPoo
{
    partial class CreateOrEditDb
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
            label1 = new Label();
            dbNameTextBox = new TextBox();
            saveBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(154, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la base de datos";
            // 
            // dbNameTextBox
            // 
            dbNameTextBox.Location = new Point(12, 40);
            dbNameTextBox.Name = "dbNameTextBox";
            dbNameTextBox.Size = new Size(329, 23);
            dbNameTextBox.TabIndex = 1;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(266, 82);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "Guardar";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // CreateOrEditDb
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 117);
            Controls.Add(saveBtn);
            Controls.Add(dbNameTextBox);
            Controls.Add(label1);
            Name = "CreateOrEditDb";
            Text = "CreateOrEditDb";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox dbNameTextBox;
        private Button saveBtn;
    }
}