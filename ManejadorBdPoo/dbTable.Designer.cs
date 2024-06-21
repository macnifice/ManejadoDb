namespace ManejadorBdPoo
{
    partial class dbTable
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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            createTableBtn = new Button();
            editBtn = new Button();
            delBtn = new Button();
            clearBtn = new Button();
            createDataBtn = new Button();
            editDataBtn = new Button();
            delDataBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(192, 393);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(221, 45);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(567, 393);
            dataGridView2.TabIndex = 1;
            // 
            // createTableBtn
            // 
            createTableBtn.Image = Properties.Resources.mas1;
            createTableBtn.Location = new Point(179, 14);
            createTableBtn.Name = "createTableBtn";
            createTableBtn.Size = new Size(25, 25);
            createTableBtn.TabIndex = 2;
            createTableBtn.UseVisualStyleBackColor = true;
            createTableBtn.Click += createTableBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Image = Properties.Resources.editar;
            editBtn.Location = new Point(148, 14);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(25, 25);
            editBtn.TabIndex = 3;
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // delBtn
            // 
            delBtn.Image = Properties.Resources.basura;
            delBtn.Location = new Point(117, 14);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(25, 25);
            delBtn.TabIndex = 4;
            delBtn.UseVisualStyleBackColor = true;
            delBtn.Click += delBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.Image = Properties.Resources.escoba;
            clearBtn.Location = new Point(86, 14);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(25, 25);
            clearBtn.TabIndex = 5;
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // createDataBtn
            // 
            createDataBtn.Image = Properties.Resources.mas1;
            createDataBtn.Location = new Point(763, 12);
            createDataBtn.Name = "createDataBtn";
            createDataBtn.Size = new Size(25, 25);
            createDataBtn.TabIndex = 6;
            createDataBtn.UseVisualStyleBackColor = true;
            createDataBtn.Click += createDataBtn_Click;
            // 
            // editDataBtn
            // 
            editDataBtn.Image = Properties.Resources.editar;
            editDataBtn.Location = new Point(732, 12);
            editDataBtn.Name = "editDataBtn";
            editDataBtn.Size = new Size(25, 25);
            editDataBtn.TabIndex = 7;
            editDataBtn.UseVisualStyleBackColor = true;
            editDataBtn.Click += editDataBtn_Click;
            // 
            // delDataBtn
            // 
            delDataBtn.Image = Properties.Resources.basura;
            delDataBtn.Location = new Point(701, 12);
            delDataBtn.Name = "delDataBtn";
            delDataBtn.Size = new Size(25, 25);
            delDataBtn.TabIndex = 8;
            delDataBtn.UseVisualStyleBackColor = true;
            delDataBtn.Click += delDataBtn_Click;
            // 
            // dbTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(delDataBtn);
            Controls.Add(editDataBtn);
            Controls.Add(createDataBtn);
            Controls.Add(clearBtn);
            Controls.Add(delBtn);
            Controls.Add(editBtn);
            Controls.Add(createTableBtn);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "dbTable";
            Text = "Tablas";
            Load += dbTable_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button createTableBtn;
        private Button editBtn;
        private Button delBtn;
        private Button clearBtn;
        private Button createDataBtn;
        private Button editDataBtn;
        private Button delDataBtn;
    }
}