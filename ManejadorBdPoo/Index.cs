using Microsoft.VisualBasic;
using System.Data;
using System.IO;

namespace ManejadorBdPoo
{
    public partial class Index : Form
    {
        private string folderPath = @"C:\DB";

        public Index()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(folderPath, "Bases.txt");

            DirectoryInfo dbDir = new DirectoryInfo(folderPath);



            if (!dbDir.Exists)
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            string[] data = getData();
            foreach (string db in data)
            {
                string directoryPath = Path.Combine(folderPath, db);
                //consultar si existe la carpeta con el nombre de este txt
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }

            getDataTable();
        }

        public void getDataTable()
        {
            DataSet set = new DataSet();
            DataTable dt = new DataTable();

            string[] data = getData();

            dt.Columns.Add("Database");

            foreach (string o in data)
            {
                dt.Rows.Add(o);
            }

            set.Tables.Add(dt);

            dataGridView1.DataSource = set.Tables[0];
        }

        private string[] getData()
        {
            string filePath = Path.Combine(folderPath, "Bases.txt");
            //consultar txt
            var existingDatabases = File.ReadAllLines(filePath);
            //devolver Array
            return existingDatabases;
        }

        private void createOrEditBdBtn_Click(object sender, EventArgs e)
        {
            CreateOrEditDb frm = new CreateOrEditDb();
            frm.index = this;
            frm.ShowDialog();

        }

        private void verBtn_Click(object sender, EventArgs e)
        {
       
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string? dbName = dataGridView1.SelectedRows[0].Cells["Database"].Value.ToString();

                if (!string.IsNullOrEmpty(dbName))
                {
                    dbTable frm = new dbTable();
                    frm.dbName = dbName;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para poder editar", "Error al editar");
            }
        }
    }
}
