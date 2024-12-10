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
    public partial class SearchDirector : Form
    {
        public SearchDirector()
        {
            InitializeComponent();

            RetroButton.ApplyStyle(closeButton, "Salir");
            RetroButton.backgroundStyle(this);

            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public event Action<string> ActorSeleccionado;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Obtener el actor seleccionado
            string actorSeleccionado = searchTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(actorSeleccionado))
            {
                // Lanza el evento con el actor seleccionado
                ActorSeleccionado?.Invoke(actorSeleccionado);

                // Cierra el formulario
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un actor válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
