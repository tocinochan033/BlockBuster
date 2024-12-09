using System;
using System.Collections;
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
    public partial class Visualizar_Peliculas : Form
    {
        public Visualizar_Peliculas()
        {
            InitializeComponent();
            CargarDatos();

            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            

            RetroButton.ApplyStyle(button1, "Agregar Pelicula");
            RetroButton.ApplyStyle(button2, "Lista Dispinible");
            RetroButton.ApplyStyle(modificarButton, "Actualizar Pelicula");
            RetroButton.ApplyStyle(closeButton, "Salir");

            RetroButton.backgroundStyle(this);

            this.FormBorderStyle = FormBorderStyle.None;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private sqlQuery query = new sqlQuery();
        public event Action datosActualizados;

        private void CargarDatos()
        {
            try
            {
                dataGridViewPeliculas.DataSource = query.ObtenerPeliculasAmplio();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            Modificar modificar = new Modificar();
            modificar.datosActualizados += CargarDatos;
            modificar.Show();
        }

        private void Visualizar_Peliculas_Load(object sender, EventArgs e)
        {
            this.Font = new Font("MS Sans Serif", 8, FontStyle.Regular);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Pelicula form = new Agregar_Pelicula();
            form.datosActualizados += CargarDatos;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaPeliculasDisponibles form = new ListaPeliculasDisponibles();
            form.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
