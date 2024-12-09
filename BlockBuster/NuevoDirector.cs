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
    public partial class NuevoDirector : Form
    {
        public NuevoDirector()
        {
            InitializeComponent();

            RetroButton.ApplyStyle(Agregarbutton, "Agregar");
            RetroButton.backgroundStyle(this);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
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
                }
                catch (Exception ex) { MessageBox.Show("Error al registrar director: " + ex.Message); }
                finally { database.close(); }

                MessageBox.Show("Registro insertado correctamente.");
            }
            datosActualizados?.Invoke();
            this.Close();
        }
    }
}
