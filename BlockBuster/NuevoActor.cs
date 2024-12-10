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
    public partial class NuevoActor : Form
    {
        public NuevoActor()
        {
            InitializeComponent();

            RetroButton.ApplyStyle(Agregarbutton, "Agregar");
            RetroButton.ApplyStyle(closeButton, "Salir");
            RetroButton.backgroundStyle(this);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private databaseConnection database = new databaseConnection();
        private sqlQuery query = new sqlQuery();

        public event Action datosActualizados;

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            // Confirmar eliminación
            var confirmResult = MessageBox.Show("¿Seguro que quieres registrar este actor?", "Confirmar actor", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    database.open();

                    string nombre = nombreTextBox.Text.ToString().ToUpper();
                    string apellido = apellidoTextBox.Text.ToString().ToUpper();

                    query.InsertarActor(nombre, apellido);
                }
                catch (Exception ex){ MessageBox.Show("Error al registrar actor: " + ex.Message); }
                finally {database.close(); }

                MessageBox.Show("Registro insertado correctamente.");
            }
            datosActualizados?.Invoke();
            this.Close();
        }

        private void NuevoActor_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
