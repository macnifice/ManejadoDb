using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorBdPoo
{
    public partial class CreateOrEditDb : Form
    {
        public Index index { get; set; }

        private string basePath = @"C:\DB";

        public CreateOrEditDb()
        {
            InitializeComponent();
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            string basesFile = Path.Combine(basePath, "Bases.txt");
            string dbName = dbNameTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show("Por favor, ingresa un nombre válido para la base de datos.");
                return;
            }

            if (!File.Exists(basesFile))
            {
                File.Create(basesFile).Dispose();
            }

            var existingDatabases = File.ReadAllLines(basesFile);

            if (existingDatabases.Contains(dbName))
            {
                MessageBox.Show("El nombre de la base de datos ya existe.");
                return;
            }

            using (StreamWriter sw = File.AppendText(basesFile))
            {
                sw.WriteLine(dbName);
            }

            Directory.CreateDirectory(Path.Combine(basePath, dbName));

            File.Create(Path.Combine(basePath, dbName, "tablas.txt")).Dispose();

            this.index.getDataTable();

            MessageBox.Show("Base de datos creada con éxito.");
            this.Close();
        }
    }
}
