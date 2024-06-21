using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace ManejadorBdPoo
{
    public partial class dbTable : Form
    {
        public string dbName { get; set; }

        private string folderPath = @"C:\DB";

        public dbTable()
        {
            InitializeComponent();
        }
        private void dbTable_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(folderPath, dbName, "tablas.txt");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            getDataTableMenu();
        }


        private void createTableBtn_Click(object sender, EventArgs e)
        {
            CreateOrEditTable frm = new CreateOrEditTable();
            frm.dbName = dbName;
            frm.dbTable = this;
            frm.Show();
        }
        public void getDataTable()
        {
            string? tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();
            string filePath = Path.Combine(folderPath, dbName, tableName + ".json");
            DataTable dt = new DataTable();

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var dataList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonData);

                    if (dataList != null && dataList.Count > 0)
                    {
                        foreach (var key in dataList[0].Keys)
                        {
                            if (key != "ID")
                            {
                                dt.Columns.Add(key);
                            }
                        }

                        // Añadir filas.
                        foreach (var dict in dataList)
                        {
                            DataRow row = dt.NewRow();
                            foreach (var key in dict.Keys)
                            {
                                if (key != "ID")
                                {
                                    row[key] = dict[key];
                                }
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            else
            {
                string path = Path.Combine(folderPath, dbName, tableName + ".txt");
                var data = File.ReadAllLines(path);
                foreach (string o in data)
                {
                    var c = o.Split("|");
                    dt.Columns.Add(c[0]);
                }
            }
            dataGridView2.DataSource = dt;
        }

        public void getDataTableMenu()
        {
            DataSet set = new DataSet();
            DataTable dt = new DataTable();

            string[] data = getDataMenu();

            dt.Columns.Add("Table");

            foreach (string o in data)
            {
                dt.Rows.Add(o);
            }

            set.Tables.Add(dt);

            dataGridView1.DataSource = set.Tables[0];
        }

        private string[] getDataMenu()
        {
            string filePath = Path.Combine(folderPath, dbName, "tablas.txt");
            //consultar txt
            var existingTables = File.ReadAllLines(filePath);
            //devolver Array
            return existingTables;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                getDataTable();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string? tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string filePath = Path.Combine(folderPath, dbName, tableName + ".txt");
                var data = File.ReadAllLines(filePath);
                CreateOrEditTable frm = new CreateOrEditTable();
                frm.DataEdit = data;
                frm.nameTable = tableName;
                frm.dbName = dbName;
                frm.EditMode = true;
                frm.dbTable = this;
                frm.Show();
            }

        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string? tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Estas seguro de eliminar esta tabla", "Advertencia", buttons);
                if (result == DialogResult.Yes)
                {
                    string filePath = Path.Combine(folderPath, dbName, tableName + ".txt");
                    string indexFilePath = Path.Combine(folderPath, dbName, "tablas.txt");
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            File.Delete(filePath);

                            if (File.Exists(indexFilePath))
                            {
                                var tables = File.ReadAllLines(indexFilePath).ToList();

                                tables.Remove(tableName);

                                File.WriteAllLines(indexFilePath, tables);
                                getDataTableMenu();
                                MessageBox.Show("Archivo y entrada eliminados con éxito.", "Información");
                            }
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Error al eliminar el archivo. " + ex.Message, "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El archivo no existe.", "Error");
                    }
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar todos los elementos de esta tabla?", "Advertencia", buttons);
                if (result == DialogResult.Yes)
                {
                    string filePath = Path.Combine(folderPath, dbName, tableName + ".json");

                    if (File.Exists(filePath))
                    {
                        // Vaciar el contenido del archivo
                        File.WriteAllText(filePath, string.Empty);

                        // Actualizar la vista
                        getDataTable();

                        MessageBox.Show("Todos los datos han sido eliminados con éxito.");
                    }
                    else
                    {
                        MessageBox.Show("El archivo no existe.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una tabla para eliminar.");
            }
        }

        private void createDataBtn_Click(object sender, EventArgs e)
        {
            string? tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string filePath = Path.Combine(folderPath, dbName, tableName + ".txt");
                var data = File.ReadAllLines(filePath);
                CreateOrEditData frm = new CreateOrEditData();
                frm.Headers = data;
                frm.tableName = tableName;
                frm.dbName = dbName;
                frm.dbTable = this;
                frm.Show();
            }
        }

        private void editDataBtn_Click(object sender, EventArgs e)
        {
            string? tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();
            string? id = dataGridView2.CurrentRow.Cells["Id"].Value.ToString();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string filePathJson = Path.Combine(folderPath, dbName, tableName + ".json");
                var dataList = new List<Dictionary<string, string>>();
                var data = new List<string>();
                if (File.Exists(filePathJson))
                {
                    string existingData = File.ReadAllText(filePathJson);
                    if (!string.IsNullOrWhiteSpace(existingData))
                    {
                        dataList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(existingData);
                        if (dataList != null)
                        {
                            var dataToEdit = dataList.FirstOrDefault(d => d["Id"] == id);
                            CreateOrEditData frm = new CreateOrEditData();
                            frm.DataToEdit = dataToEdit;
                            frm.tableName = tableName;
                            frm.dbName = dbName;
                            frm.dbTable = this;
                            frm.EditMode = true;
                            frm.Show();
                        }
                    }
                }


            }
        }

        private void delDataBtn_Click(object sender, EventArgs e)
        {
            var tableName = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();
            var selectedId = dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Estas seguro de eliminar esta tabla", "Advertencia", buttons);
                if (result == DialogResult.Yes)
                {
                    string filePath = Path.Combine(folderPath, dbName, tableName + ".json");

                    if (File.Exists(filePath))
                    {
                        string jsonData = File.ReadAllText(filePath);
                        var dataList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonData);

                        if (dataList != null && dataList.Any())
                        {

                            var itemToRemove = dataList.FirstOrDefault(d => d["Id"] == selectedId);

                            if (itemToRemove != null)
                            {
                                dataList.Remove(itemToRemove);

                                string updatedJsonData = JsonSerializer.Serialize(dataList, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(filePath, updatedJsonData);
                                getDataTable();
                                MessageBox.Show("Datos eliminados con éxito.");
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }

        }
    }
}
