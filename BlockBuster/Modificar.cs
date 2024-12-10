using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();

            RetroButton.ApplyStyle(button1, "Cambiar Estatus");
            RetroButton.ApplyStyle(eliminarButton, "Eliminar");
            RetroButton.ApplyStyle(closeButton, "Salir");

            this.FormBorderStyle = FormBorderStyle.None;
            RetroButton.backgroundStyle(this);
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        private sqlQuery query = new sqlQuery();
        private databaseConnection database =  new databaseConnection(); 
        public event Action datosActualizados;

        Agregar_Pelicula estatus = new Agregar_Pelicula();
        private void cargarEstatus()
        {
            estatus.LlenarComboBox(estatusComboBox, "SELECT estatus FROM estatus", "estatus");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar que el título no esté vacío
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("Por favor, selecciona una película antes de cambiar el estatus.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se haya seleccionado un nuevo estatus
            if (estatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un estatus válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los valores del formulario
            string titulo = nombreTextBox.Text.Trim();
            string nuevoEstatus = estatusComboBox.SelectedItem.ToString();

            try
            {
                database.open();

                // Consulta para actualizar el estatus de la película
                string query = @"
                    UPDATE pelicula
                    SET id_estatus = (SELECT id_estatus FROM estatus WHERE estatus = @NuevoEstatus)
                    WHERE titulo = @Titulo";

                using (SqlCommand command = new SqlCommand(query, database.connectiondb))
                {
                    command.Parameters.AddWithValue("@NuevoEstatus", nuevoEstatus);
                    command.Parameters.AddWithValue("@Titulo", titulo);

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Estatus actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        estatusTextBox.Text = nuevoEstatus; // Actualiza el TextBox de estatus
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la película especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el estatus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.close();
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            // Validar que el título no esté vacío
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("Por favor, selecciona una película antes de eliminarla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de eliminación
            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar esta película? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.No)
            {
                return; // Si el usuario selecciona "No", no se realiza ninguna acción
            }

            // Obtener el título de la película
            string titulo = nombreTextBox.Text.Trim();

            try
            {
                database.open();

                // Consulta para eliminar la película
                string query = "DELETE FROM pelicula WHERE titulo = @Titulo";

                using (SqlCommand command = new SqlCommand(query, database.connectiondb))
                {
                    command.Parameters.AddWithValue("@Titulo", titulo);

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Película eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos(); // Limpia los TextBox y demás controles del formulario
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la película especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar la película: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.close();
            }
        }

        private void LimpiarCampos()
        {
            nombreTextBox.Text = "";
            estatusTextBox.Text = "";
            idiomaTextBox.Text = "";
            estatusComboBox.SelectedIndex = -1;
            searchTextBox.Text = "";
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

            cargarEstatus();

            try
            {
                database.open();

                // Consulta para obtener los datos de la película
                ////string query = @"
                ////   SELECT p.titulo AS Titulo, p.fecha AS Fecha, i.idioma AS Idioma, e.estatus AS Estatus
                ////   FROM pelicula p
                ////        INNER JOIN idioma i ON p.id_idioma = i.id_idioma
                ////        INNER JOIN estatus e ON p.id_estatus = e.id_estatus
                ////        INNER JOIN director d ON p.id_director = d.id_director
                ////        WHERE p.titulo = @Titulo";
                ///

                string new_query = query.search();

                using (SqlCommand command = new SqlCommand(new_query, database.connectiondb))
                {
                    command.Parameters.AddWithValue("@Titulo", titulo);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Cargar los datos en los TextBox correspondientes
                            nombreTextBox.Text = reader["Titulo"].ToString();
                            estatusTextBox.Text = reader["Estatus"].ToString();
                            idiomaTextBox.Text = reader["Idioma"].ToString();
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
