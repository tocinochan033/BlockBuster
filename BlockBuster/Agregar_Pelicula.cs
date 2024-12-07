using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster
{
    public partial class Agregar_Pelicula : Form
    {
        private databaseConnection database = new databaseConnection();
        sqlQuery query = new sqlQuery();
        private IDHelper helper = new IDHelper();
        
        public Agregar_Pelicula()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            database.open();

            // Datos del forumulario
            string nombre = nombreTextBox.Text;
            int fecha = int.Parse(fechaTextBox.Text);
            int duracion = int.Parse(duracionTextBox.Text);

            string nombreDirector = nombreDirectorTextBox.Text;
            string apellidoDirector = apellidoDirectorTextBox.Text;

            string nombreActor = actorNombreTextBox.Text;
            string apellidoActor = actorApellidoTextBox.Text;

            string genero = generoComboBox.SelectedItem.ToString();
            string idioma = idiomaComboBox.SelectedItem.ToString();
            string estatus = estatusComboBox.SelectedItem.ToString();

            // Verificar si ya existen los registros y obtener sus IDs
            int idActor = helper.ObtenerIdPorNombre(nombreActor, "actor", "nombre");
            if (idActor == -1)
            {
                idActor = query.InsertarActor(nombreActor, apellidoActor); // Insertar actor si no existe
            }

            int idDirector = helper.ObtenerIdPorNombre(nombreDirector, "director", "nombre");
            if (idDirector == -1)
            {
                idDirector = query.InsertarDirector(nombreDirector, apellidoDirector); // Insertar director si no existe
            }

            int idGenero = helper.ObtenerIdPorNombre(genero, "genero", "genero");
            if (idGenero == -1)
            {
                idGenero = query.InsertarGenero(genero); // Insertar genero si no existe
            }

            int idIdioma = helper.ObtenerIdPorNombre(idioma, "idioma", "idioma");
            if (idIdioma == -1)
            {
                idIdioma = query.InsertarIdioma(idioma); // Insertar idioma si no existe
            }

            int idEstatus = helper.ObtenerIdPorNombre(estatus, "estatus", "estatus");
            if (idEstatus == -1)
            {
                idEstatus = query.InsertarEstatus(estatus); // Insertar estatus si no existe
            }

            // Insertar película con las relaciones
            query.InsertarPelicula(nombre, fecha, duracion, idIdioma, idGenero, idEstatus, idActor, idDirector);

            database.close();

            //muestra el formulario donde se lee la tabla pelicula
            Visualizar_Peliculas forms2 = new Visualizar_Peliculas();
            forms2.Show();
        }

        public void LlenarComboBox(ComboBox comboBox, string query, string displayField)
        {
            try
            {
                // Utiliza la conexión desde la clase databaseConnection
                SqlConnection connection = database.getConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                comboBox.Items.Clear(); // Limpia el ComboBox para evitar duplicados

                while (reader.Read())
                {
                    comboBox.Items.Add(reader[displayField].ToString()); // Agrega solo el texto
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
            // No es necesario cerrar la conexión aquí si usas un bloque using o en el método `close`
        }





        public void CargarDatos()
        {
            LlenarComboBox(generoComboBox, "SELECT genero FROM genero", "genero");
            LlenarComboBox(idiomaComboBox, "SELECT idioma FROM idioma", "idioma");
            LlenarComboBox(estatusComboBox, "SELECT estatus FROM estatus", "estatus");
        }

        private void generoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
