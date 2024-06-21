namespace ManejadorBdPoo
{
    public partial class CreateOrEditTable : Form
    {
        public dbTable? dbTable { get; set; }
        public string[] DataEdit { get; set; }
        public bool EditMode { get; set; }

        int controlCount = 0;
        public string dbName { get; set; } 
        public string nameTable { get; set; }
        private string basePath = @"C:\DB";

        public CreateOrEditTable()
        {
            InitializeComponent();
        }

        private void CreateOrEditTable_Load(object sender, EventArgs e)
        {
            label2.Text = controlCount + 1.ToString();
            if (!EditMode)
            {
                AddControls("Id","Int","5");
            }
            else
            {
                string[] data = DataEdit;
                textBox1.Text = nameTable;
                textBox1.Enabled = false;

                foreach (string s in data)
                {
                    var d = s.Split("|");
                    AddControls(d[0], d[1], d[2]);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveLastControls();
        }

        private void AddControls(string campo = "", string dato = "", string tamaño = "")
        {
            int baseTop = 160;
            int offset = 70;

            int currentTop = baseTop + (controlCount * offset);

            Label newLabelTitle = new Label();
            newLabelTitle.AutoSize = true;
            newLabelTitle.Location = new Point(12, currentTop - 40);
            newLabelTitle.Text = $"Atributo {controlCount + 1}";
            this.Controls.Add(newLabelTitle);


            TextBox newTextBoxCampo = new TextBox();
            if (campo.Trim().ToLower() == "id")
            {
                newTextBoxCampo.Enabled = false;
            }
            newTextBoxCampo.Text = campo;
            newTextBoxCampo.Location = new Point(12, currentTop);
            newTextBoxCampo.Size = new Size(108, 23);
            this.Controls.Add(newTextBoxCampo);

            Label newLabelCampo = new Label();
            newLabelCampo.AutoSize = true;
            newLabelCampo.Location = new Point(12, currentTop - 18);
            newLabelCampo.Text = "Campo";
            this.Controls.Add(newLabelCampo);

            TextBox newTextBoxDato = new TextBox();
            if (campo.Trim().ToLower() == "id")
            {
                newTextBoxDato.Enabled = false;
            }
            newTextBoxDato.Text = dato;
            newTextBoxDato.Location = new Point(126, currentTop);
            newTextBoxDato.Size = new Size(108, 23);
            this.Controls.Add(newTextBoxDato);

            Label newLabelDato = new Label();
            newLabelDato.AutoSize = true;
            newLabelDato.Location = new Point(126, currentTop - 18);
            newLabelDato.Text = "Tipo Dato";
            this.Controls.Add(newLabelDato);

            TextBox newTextBoxTamaño = new TextBox();
            if (campo.Trim().ToLower() == "id")
            {
                newTextBoxTamaño.Enabled = false;
            }
            newTextBoxTamaño.Text = tamaño;
            newTextBoxTamaño.Location = new Point(240, currentTop);
            newTextBoxTamaño.Size = new Size(108, 23);
            this.Controls.Add(newTextBoxTamaño);

            Label newLabelTamaño = new Label();
            newLabelTamaño.AutoSize = true;
            newLabelTamaño.Location = new Point(240, currentTop - 18);
            newLabelTamaño.Text = "Tamaño";
            this.Controls.Add(newLabelTamaño);

            var sum = controlCount + 1;
            label2.Text = sum.ToString();
            controlCount++;
        }
        private void RemoveLastControls()
        {
            if (controlCount > 1)
            {
                controlCount--;

                int baseTop = 160; 
                int offset = 70;   

                int currentTop = baseTop + (controlCount * offset);

                List<Control> controlsToRemove = new List<Control>();

                foreach (Control c in this.Controls)
                {
                    if ((c is TextBox || c is Label) &&
                        (c.Location.Y == currentTop || c.Location.Y == currentTop - 18 || c.Location.Y == currentTop - 40))
                    {
                        controlsToRemove.Add(c);
                    }
                }
                foreach (Control c in controlsToRemove)
                {

                    this.Controls.Remove(c);
                    c.Dispose();

                }
                var rest = controlCount - 1;
                label2.Text = rest.ToString();
            }
            else
            {
                MessageBox.Show("No existe un componente que remover.");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tableName = textBox1.Text.Trim().ToLower();
            string filePath = Path.Combine(basePath, dbName, "tablas.txt");
            string filePathTable = Path.Combine(basePath, dbName, tableName + ".txt");

            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("El nombre de la tabla es requerido.");
                return;
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            List<string> attributeData = new List<string>();
            if (!EditMode)
            {
                var existingTable = File.ReadAllLines(filePath);

                if (existingTable.Contains(tableName))
                {
                    MessageBox.Show("El nombre de la tabla ya existe.");
                    return;
                }
            }

            CreateOrEdiTable(attributeData, tableName, filePath, filePathTable);

        }

        private void CreateOrEdiTable(List<string> attributeData, string tableName, string filePath, string filePathTable)
        {
            int baseTop = 160;
            int offset = 70;

            // Verifica todos los datos primero
            for (int i = 0; i < controlCount; i++)
            {
                int currentTop = baseTop + (i * offset);

                var textBoxCampo = this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Location == new Point(12, currentTop));
                var textBoxDato = this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Location == new Point(126, currentTop));
                var textBoxTamaño = this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Location == new Point(240, currentTop));

                if (!string.IsNullOrEmpty(textBoxCampo.Text) && !string.IsNullOrEmpty(textBoxDato.Text) && !string.IsNullOrEmpty(textBoxTamaño.Text))
                {
                    attributeData.Add($"{textBoxCampo.Text} | {textBoxDato.Text} | {textBoxTamaño.Text} | H |");
                }
                else
                {
                    MessageBox.Show("No es posible guardar uno de tus atributos les falta información.");
                    return;
                }
            }
            if (!EditMode)
            {
                // Si todos los datos son correctos, procede a guardarlos
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(tableName);
                }
            }

            if (!File.Exists(filePathTable))
            {
                File.Create(filePathTable).Dispose();
            }

            using (StreamWriter writer = new StreamWriter(filePathTable))
            {
                foreach (string data in attributeData)
                {
                    writer.WriteLine(data);
                }
            }
            this.dbTable.getDataTableMenu();
    
            if (!EditMode)
            {
                MessageBox.Show("Tabla creada con éxito.");
            }
            else
            {
                this.dbTable.getDataTable();
                MessageBox.Show("Tabla edita con éxito.");
            }
            this.Close();
        }



    }
}

