using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster
{
    public partial class ListaPeliculasDisponibles : Form
    {
        public ListaPeliculasDisponibles()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            RetroButton.ApplyStyle(closeButton, "salir");
            RetroButton.ApplyStyle(searchButton, "Buscar");

            RetroButton.backgroundStyle(this);

            cargarDatos();
        }

        private void ListaPeliculasDisponibles_Load(object sender, EventArgs e)
        {

        }


        private sqlQuery query = new sqlQuery();
        private databaseConnection database = new databaseConnection();
        private Agregar_Pelicula agregar = new Agregar_Pelicula();  

        void cargarDatos()
        {
            agregar.LlenarComboBox(searchCombobox, "SELECT titulo FROM pelicula", "titulo");
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Validar que el campo de búsqueda no esté vacío
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                MessageBox.Show("Por favor, ingresa el título de la película que deseas buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el título de la película a buscar
            string titulo = searchTextBox.Text.Trim();

            try
            {
                database.open();

                // Consulta para obtener los datos de la película
                string query = @"
                   SELECT p.titulo AS Titulo, p.fecha AS Fecha, p.duracion_min AS Duracion, 
                   g.genero AS Genero, i.idioma AS Idioma, e.estatus AS Estatus, 
                   CONCAT(a.nombre, ' ', a.apellido) AS Actor, 
                   CONCAT(d.nombre, ' ', d.apellido) AS Director
                   FROM pelicula p
                        INNER JOIN genero g ON p.id_genero = g.id_genero
                        INNER JOIN idioma i ON p.id_idioma = i.id_idioma
                        INNER JOIN estatus e ON p.id_estatus = e.id_estatus
                        INNER JOIN actor a ON p.id_actor = a.id_actor
                        INNER JOIN director d ON p.id_director = d.id_director
                        WHERE p.titulo = @Titulo";

                using (SqlCommand command = new SqlCommand(query, database.connectiondb))
                {
                    command.Parameters.AddWithValue("@Titulo", titulo);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Cargar los datos en los TextBox correspondientes
                            nombreTextBox.Text = reader["Titulo"].ToString();
                            fechaTextBox.Text = reader["Fecha"].ToString();
                            duracionTextBox.Text = reader["Duracion"].ToString();
                            generoTextBox.Text = reader["Genero"].ToString();
                            idiomaTextBox.Text = reader["Idioma"].ToString();
                            estatusTextBox.Text = reader["Estatus"].ToString();
                            actorTextBox.Text = reader["Actor"].ToString();
                            directorTextBox.Text = reader["Director"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna película con ese título.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                database.close();
            }
        }
    }
}
