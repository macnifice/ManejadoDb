

using System.Text.Json;
using System.Windows.Forms;

namespace ManejadorBdPoo
{
    public partial class CreateOrEditData : Form
    {
        public dbTable? dbTable { get; set; }
        int controlCount = 0;
        public bool EditMode { get; set; }
        public string dbName { get; set; }
        public string tableName { get; set; }
        public string[] Headers { get; set; }
        public Dictionary<string, string> DataToEdit { get; set; }
        private string basePath = @"C:\DB";

        public CreateOrEditData()
        {
            InitializeComponent();
        }

        private void CreateOrEditData_Load(object sender, EventArgs e)
        {
            Label newLabel = new Label();
            newLabel.AutoSize = true;
            newLabel.Location = new Point(12, 20);
            newLabel.Text = "Datos Generales";
            this.Controls.Add(newLabel);

            if (!EditMode)
            {
                string[] inputs = Headers;


                foreach (string o in inputs)
                {
                    string[] d = o.Split('|');

                    AddControls(d[0]);
                }
            }
            else if (EditMode && DataToEdit != null)
            {
                foreach (var key in DataToEdit.Keys)
                {
                    AddControls(key, DataToEdit[key]);
                }
            }
                AddButtons();
        }

        private void AddControls(string label = "", string textBox = "")
        {
            int baseTop = 70;
            int offset = 60;

            int currentTop = baseTop + (controlCount * offset);

            Label newLabel = new Label();
            newLabel.AutoSize = true;
            newLabel.Location = new Point(12, currentTop - 18);
            newLabel.Text = label;
            this.Controls.Add(newLabel);

            TextBox newTextBox = new TextBox();
            if (label.Trim().ToLower() == "id")
            {
                newTextBox.Enabled = false;
            }
            newTextBox.Text = textBox;
            newTextBox.Location = new Point(12, currentTop);
            newTextBox.Size = new Size(216, 25);
            this.Controls.Add(newTextBox);

            controlCount++;
        }

        private void AddButtons()
        {
            int baseTop = 70;
            int offset = 60;
            int currentTop = baseTop + (controlCount * offset);
            Button button = new Button();
            button.Text = "Guardar";
            button.Location = new Point(155, currentTop - 18);
            button.Click += new EventHandler(ButtonSave_Click);
            this.Controls.Add(button);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string filePathTable = Path.Combine(basePath, dbName, tableName + ".json");
  
            Dictionary<string, string> data = new Dictionary<string, string>();

            var labels = this.Controls.OfType<Label>().Where(l => l.Text != "Datos Generales" && !string.IsNullOrWhiteSpace(l.Text)).ToList();
            var textboxes = this.Controls.OfType<TextBox>().OrderBy(t => t.Location.Y).ToList();

            for (int i = 0; i < labels.Count; i++)
            {
                string label = labels[i].Text.Trim();
                string value = textboxes[i].Text.Trim();
                data[label] = value;
            }

            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();
            int nextId = 1;

            if (File.Exists(filePathTable))
            {
                string existingData = File.ReadAllText(filePathTable);
                if (!string.IsNullOrWhiteSpace(existingData))
                {
                    dataList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(existingData);
                    if (dataList.Any())
                    {
                        nextId = dataList.Max(d => int.Parse(d["Id"])) + 1;
                    }
                }
            }

            if (EditMode)
            {
                // En modo edición, actualizar el conjunto de datos existente.
                var itemToEdit = dataList.FirstOrDefault(d => d["Id"] == DataToEdit["Id"]);
                if (itemToEdit != null)
                {
                    foreach (var key in data.Keys)
                    {
                        itemToEdit[key] = data[key];
                    }
                }
            }
            else
            {     
                data["Id"] = nextId.ToString();
                dataList.Add(data);
            }

            string jsonData = JsonSerializer.Serialize(dataList, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePathTable, jsonData);

            this.dbTable.getDataTable();
            MessageBox.Show("Datos guardados con éxito.");
            this.Close();

        }


    }
}
