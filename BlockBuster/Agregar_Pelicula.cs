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
    public partial class Agregar_Pelicula : Form
    {
        databaseConnection conexion = new databaseConnection();
        public Agregar_Pelicula()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            conexion.open();

            // Datos del forumulario
            string nombre = nombreTextBox.Text;
            int fecha = int.Parse(fechaTextBox.Text);
            int duracion = int.Parse(duracionTextBox.Text);

            string nombreDirector = nombreDirectorTextBox.Text;
            string apellidoDirector = apellidoDirectorTextBox.Text;

            string nombreActor = actorNombreTextBox.Text;
            string apellidoActor = actorApellidoTextBox.Text;

            string genero = generoComboBox.SelectedItem.ToString();
            string idioma = idiomaComboBox.SelectedItem.ToString();
            string estatus = estatusComboBox.SelectedItem.ToString();

            // Insertar actor, director, género, idioma y estatus
            int idActor = conexion.InsertarActor(nombreActor, apellidoActor);
            int idDirector = conexion.InsertarDirector(nombreDirector, apellidoDirector);
            int idGenero = conexion.InsertarGenero(genero);
            int idIdioma = conexion.InsertarIdioma(idioma);
            int idEstatus = conexion.InsertarEstatus(estatus);

            // Insertar película con las relaciones
            conexion.InsertarPelicula(nombre, fecha, duracion, idIdioma, idGenero, idEstatus, idActor, idDirector);

            //muestra el formulario donde se lee la tabla pelicula
            Visualizar_Peliculas forms2 = new Visualizar_Peliculas();
            forms2.Show();
        }

        private void generoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
