using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            CargarDatos();

            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            RetroButton.backgroundStyle(this);
        }

        private void ListaPeliculasDisponibles_Load(object sender, EventArgs e)
        {

        }


        private sqlQuery query = new sqlQuery();


        private void CargarDatos()
        {
            try
            {
                dataGridViewPeliculas.DataSource = query.ObtenerPeliculasAmplioFiltrado();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
