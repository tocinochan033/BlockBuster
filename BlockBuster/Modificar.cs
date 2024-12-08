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
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
            CargarDatos();
            cargarEstatus();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        sqlQuery query = new sqlQuery();
        private void CargarDatos()
        {
            try
            {
                dataGridViewPeliculas.DataSource = query.ObtenerPeliculasMenor();
                dataGridViewPeliculas.Columns["Identificador"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Agregar_Pelicula estatus = new Agregar_Pelicula();
        private void cargarEstatus()
        {
            estatus.LlenarComboBox(estatusComboBox, "SELECT estatus FROM estatus", "estatus");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeliculas.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtén el ID de la película seleccionada
                    int idPelicula = Convert.ToInt32(dataGridViewPeliculas.SelectedRows[0].Cells["Identificador"].Value);

                    // Obtén el nuevo estatus seleccionado del ComboBox
                    string nuevoEstatus = estatusComboBox.SelectedItem?.ToString();

                    if (string.IsNullOrEmpty(nuevoEstatus))
                    {
                        MessageBox.Show("Por favor, selecciona un estatus válido.");
                        return;
                    }

                    // Actualizar el estatus en la base de datos
                    using (SqlConnection connection = new SqlConnection("Data Source= MARTIN\\SQLEXPRESS; Initial Catalog= COCKBUSTERS; Integrated Security=True"))
                    {
                        connection.Open();
                        string query = @"
                        UPDATE pelicula 
                        SET id_estatus = (SELECT TOP 1 id_estatus FROM estatus WHERE estatus = @NuevoEstatus) 
                        WHERE id_pelicula = @IdPelicula";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NuevoEstatus", nuevoEstatus);
                            command.Parameters.AddWithValue("@IdPelicula", idPelicula);

                            int filasAfectadas = command.ExecuteNonQuery();
                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Estatus modificado correctamente.");
                                CargarDatos(); // Recarga el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se pudo modificar el estatus.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el estatus: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para modificar.");
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada
            if (dataGridViewPeliculas.SelectedRows.Count > 0)
            {
                // Obtén el ID de la fila seleccionada (supongamos que la columna del ID es la primera columna)
                int idPelicula = Convert.ToInt32(dataGridViewPeliculas.SelectedRows[0].Cells["Identificador"].Value);

                // Confirmar eliminación
                var confirmResult = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Conexión a la base de datos y eliminación del registro
                        using (SqlConnection connection = new SqlConnection("Data Source= MARTIN\\SQLEXPRESS; Initial Catalog= COCKBUSTERS; Integrated Security=True"))
                        {
                            connection.Open();
                            string query = "DELETE FROM pelicula WHERE id_pelicula = @IdPelicula";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@IdPelicula", idPelicula);
                                command.ExecuteNonQuery();
                            }
                        }

                        // Mensaje de éxito
                        MessageBox.Show("Registro eliminado correctamente.");

                        // Recarga los datos del DataGridView
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }
    }
}
