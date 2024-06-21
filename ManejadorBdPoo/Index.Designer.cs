namespace ManejadorBdPoo
{
    partial class Index
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
            dataGridView1 = new DataGridView();
            createOrEditBdBtn = new Button();
            verBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 43);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(393, 395);
            dataGridView1.TabIndex = 1;
            // 
            // createOrEditBdBtn
            // 
            createOrEditBdBtn.Location = new Point(330, 14);
            createOrEditBdBtn.Name = "createOrEditBdBtn";
            createOrEditBdBtn.Size = new Size(75, 23);
            createOrEditBdBtn.TabIndex = 2;
            createOrEditBdBtn.Text = "Agregar";
            createOrEditBdBtn.UseVisualStyleBackColor = true;
            createOrEditBdBtn.Click += createOrEditBdBtn_Click;
            // 
            // verBtn
            // 
            verBtn.Location = new Point(249, 14);
            verBtn.Name = "verBtn";
            verBtn.Size = new Size(75, 23);
            verBtn.TabIndex = 3;
            verBtn.Text = "Ver";
            verBtn.UseVisualStyleBackColor = true;
            verBtn.Click += verBtn_Click;
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 450);
            Controls.Add(verBtn);
            Controls.Add(createOrEditBdBtn);
            Controls.Add(dataGridView1);
            Name = "Index";
            Text = "Gestor base de datos";
            Load += Index_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button createOrEditBdBtn;
        private Button verBtn;
    }
}
