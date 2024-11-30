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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private sqlQuery query = new sqlQuery();


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
            modificar.Show();
        }
    }
}
