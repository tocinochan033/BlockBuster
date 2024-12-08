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

            string genero = generoComboBox.SelectedItem.ToString();
            string idioma = idiomaComboBox.SelectedItem.ToString();
            string estatus = estatusComboBox.SelectedItem.ToString();

            // Obtener el actor seleccionado
            string actorSeleccionado = actorComboBox.SelectedItem.ToString();
            string[] partesActor = actorSeleccionado.Split(' '); // Divide el texto en nombre y apellido
            string nombreActor = partesActor[0];
            string apellidoActor = partesActor.Length > 1 ? partesActor[1] : ""; // Maneja el caso de un solo nombre

            // Obtener el director seleccionado
            string directorSeleccionado = directorComboBox.SelectedItem.ToString();
            string[] partesDirector = directorSeleccionado.Split(' '); // Divide el texto en nombre y apellido
            string nombreDirector = partesDirector[0];
            string apellidoDirector = partesDirector.Length > 1 ? partesDirector[1] : ""; // Maneja el caso de un solo nombre


            //Verificar si ya existen los registros y obtener sus IDs
            int idActor = helper.ObtenerIdPorNombreYApellido(nombreActor, apellidoActor, "actor");
            if (idActor == -1)
            {
                idActor = query.InsertarActor(nombreActor, apellidoActor);
            }

            int idDirector = helper.ObtenerIdPorNombreYApellido(nombreDirector, apellidoDirector, "director");
            if (idDirector == -1)
            {
                idDirector = query.InsertarDirector(nombreDirector, apellidoDirector);
            }


            int idGenero = helper.ObtenerIdPorNombre(genero, "genero", "genero");
            if (idGenero == -1)
            {
                idGenero = query.InsertarGenero(genero); 
            }

            int idIdioma = helper.ObtenerIdPorNombre(idioma, "idioma", "idioma");
            if (idIdioma == -1)
            {
                idIdioma = query.InsertarIdioma(idioma); 
            }

            int idEstatus = helper.ObtenerIdPorNombre(estatus, "estatus", "estatus");
            if (idEstatus == -1)
            {
                idEstatus = query.InsertarEstatus(estatus); 
            }

            // Insertar película con las relaciones
            query.InsertarPelicula(nombre, fecha, duracion, idIdioma, idGenero, idEstatus, idActor, idDirector);

            database.close();


            Visualizar_Peliculas forms2 = new Visualizar_Peliculas();
            forms2.Show();
        }

        public void LlenarComboBox(ComboBox comboBox, string query, string displayField)
        {
            try
            {
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
                    comboBox.Items.Add(reader[displayField].ToString()); 
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
            
        }

        public void LlenarComboBoxConDosCampos(ComboBox comboBox, string query, string campoNombre, string campoApellido)
        {
            try
            {
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
                    // Concatenar nombre y apellido
                    string item = reader[campoNombre].ToString() + " " + reader[campoApellido].ToString();
                    comboBox.Items.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }



        public void CargarDatos()
        {
            LlenarComboBox(generoComboBox, "SELECT genero FROM genero", "genero");
            LlenarComboBox(idiomaComboBox, "SELECT idioma FROM idioma", "idioma");
            LlenarComboBox(estatusComboBox, "SELECT estatus FROM estatus", "estatus");

            // Llenar ComboBox de actores
            LlenarComboBoxConDosCampos(actorComboBox, "SELECT nombre, apellido FROM actor", "nombre", "apellido");

            // Llenar ComboBox de directores
            LlenarComboBoxConDosCampos(directorComboBox, "SELECT nombre, apellido FROM director", "nombre", "apellido");
        }

        void actualizarDatos()
        {
            // Llenar ComboBox de actores
            LlenarComboBoxConDosCampos(actorComboBox, "SELECT nombre, apellido FROM actor", "nombre", "apellido");

            // Llenar ComboBox de directores
            LlenarComboBoxConDosCampos(directorComboBox, "SELECT nombre, apellido FROM director", "nombre", "apellido");
        }

        private void generoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void directorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoActor actor = new NuevoActor();
            actor.datosActualizados += actualizarDatos;
            actor.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoDirector director = new NuevoDirector();
            director.datosActualizados += actualizarDatos;
            director.ShowDialog();
        }
    }
}
