using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BlockBuster
{
    public partial class NuevoDirector : Form
    {
        public NuevoDirector()
        {
            InitializeComponent();

            RetroButton.ApplyStyle(Agregarbutton, "Agregar");
            RetroButton.backgroundStyle(this);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private databaseConnection database = new databaseConnection();
        sqlQuery query = new sqlQuery();

        public event Action datosActualizados;

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            // Confirmar eliminación
            var confirmResult = MessageBox.Show("¿Seguro que quieres registrar este director?", "Confirmar director", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    database.open();

                    string nombre = nombreTextBox.Text.ToString();
                    string apellido = apellidoTextBox.Text.ToString();

                    query.InsertarDirector(nombre, apellido);


                    MessageBox.Show("Registro insertado correctamente.");
                    datosActualizados?.Invoke();
                }
                catch (Exception ex) { MessageBox.Show("Error al registrar director: " + ex.Message); }
                finally { database.close(); }

            }

            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void apellidoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
