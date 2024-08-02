using System.Data;
using System.Data.SqlClient;

namespace comboboxdb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Cadena de conexión a la base de datos
            string connectionString = "Server=.;Initial Catalog=Empresa; Integrated Security = true";
            // Consulta SQL para obtener los datos de la tabla Departamentos
            string query = "SELECT Id, Nombre FROM Departamentos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Llenar un DataTable con los datos obtenidos
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar los datos al ComboBox
                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "Nombre";
                    comboBox1.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

