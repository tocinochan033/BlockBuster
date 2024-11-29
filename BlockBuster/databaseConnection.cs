using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace BlockBuster
{
    internal class databaseConnection
    {
        string connection = "Data Source= MARTIN\\SQLEXPRESS; Initial Catalog= COCKBUSTERS; Integrated Security=True";
        public SqlConnection connectiondb = new SqlConnection();

        public databaseConnection() 
        { 
            connectiondb.ConnectionString = connection;
        }

        public void open()
        {
            try
            {
                connectiondb.Open();
                Console.WriteLine("Conexion Abierta.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abir la base de datos. ", ex.Message);
            }
        }

        public void close()
        {
            connectiondb.Close();
        }

        public int InsertarActor(string nombre, string apellido)
        {
            int idActor = 0;

            try
            {
                open();
                string query = "INSERT INTO actor (nombre, apellido) OUTPUT INSERTED.id_actor VALUES (@Nombre, @Apellido)";
                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);

                    idActor = (int)command.ExecuteScalar(); // Obtiene el ID del actor insertado
                }

                Console.WriteLine("Actor insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar actor: " + ex.Message);
            }
            finally
            {
                close();
            }

            return idActor;
        }

        public int InsertarDirector(string nombre, string apellido)
        {
            int idDirector = 0;

            try
            {
                open();
                string query = "INSERT INTO director (nombre, apellido) OUTPUT INSERTED.id_director VALUES (@Nombre, @Apellido)";
                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);

                    idDirector = (int)command.ExecuteScalar(); // Obtiene el ID del director insertado
                }

                Console.WriteLine("Director insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar director: " + ex.Message);
            }
            finally
            {
                close();
            }

            return idDirector;
        }

        public int InsertarGenero(string genero)
        {
            int idGenero = 0;

            try
            {
                open();
                string query = "INSERT INTO genero (genero) OUTPUT INSERTED.id_genero VALUES (@Genero)";
                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    command.Parameters.AddWithValue("@Genero", genero);

                    idGenero = (int)command.ExecuteScalar(); // Obtiene el ID del género insertado
                }

                Console.WriteLine("Género insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar género: " + ex.Message);
            }
            finally
            {
                close();
            }

            return idGenero;
        }

        public int InsertarIdioma(string idioma)
        {
            int idIdioma = 0;

            try
            {
                open();
                string query = "INSERT INTO idioma (idioma) OUTPUT INSERTED.id_idioma VALUES (@Idioma)";
                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    command.Parameters.AddWithValue("@Idioma", idioma);

                    idIdioma = (int)command.ExecuteScalar(); // Obtiene el ID del género insertado
                }

                Console.WriteLine("Idioma insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar Idioma: " + ex.Message);
            }
            finally
            {
                close();
            }

            return idIdioma;
        }

        public int InsertarEstatus(string estatus)
        {
            int idEstatus = 0;

            try
            {
                open();
                string query = "INSERT INTO estatus (estatus) OUTPUT INSERTED.id_estatus VALUES (@Estatus)";
                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    command.Parameters.AddWithValue("@Estatus", estatus);

                    idEstatus = (int)command.ExecuteScalar(); // Obtiene el ID del género insertado
                }

                Console.WriteLine("Estatus insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar estatus: " + ex.Message);
            }
            finally
            {
                close();
            }

            return idEstatus;
        }

        public void InsertarPelicula(string titulo, int fecha, int duracion, int idIdioma, int idGenero, int idEstatus, int idActor, int idDirector)
        {
            try
            {
                open();
                string query = "INSERT INTO pelicula (titulo, fecha, duracion_min, id_idioma, id_genero, id_estatus, id_actor, id_director) " +
                               "VALUES (@Titulo, @Fecha, @Duracion, @IdIdioma, @IdGenero, @IdEstatus, @IdActor, @IdDirector)";
                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    command.Parameters.AddWithValue("@Titulo", titulo);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.Parameters.AddWithValue("@Duracion", duracion);
                    command.Parameters.AddWithValue("@IdIdioma", idIdioma);
                    command.Parameters.AddWithValue("@IdGenero", idGenero);
                    command.Parameters.AddWithValue("@IdEstatus", idEstatus);
                    command.Parameters.AddWithValue("@IdActor", idActor);
                    command.Parameters.AddWithValue("@IdDirector", idDirector);

                    // Ejecuta la consulta
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Película insertada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar película: " + ex.Message);
            }
            finally
            {
                close();
            }
        }

        public DataTable ObtenerPeliculas()
        {
            DataTable dataTable = new DataTable();
            try
            {
                open();
                string query = @"
            SELECT 
                p.titulo AS 'Título', 
                p.fecha AS 'Fecha de Estreno', 
                p.duracion_min AS 'Duración (minutos)',
                a.nombre + ' ' + a.apellido AS 'Actor',
                d.nombre + ' ' + d.apellido AS 'Director',
                g.genero AS 'Género',
                i.idioma AS 'Idioma',
                e.estatus AS 'Estatus'
            FROM pelicula p
            INNER JOIN actor a ON p.id_actor = a.id_actor
            INNER JOIN director d ON p.id_director = d.id_director
            INNER JOIN genero g ON p.id_genero = g.id_genero
            INNER JOIN idioma i ON p.id_idioma = i.id_idioma
            INNER JOIN estatus e ON p.id_estatus = e.id_estatus";

                using (SqlCommand command = new SqlCommand(query, connectiondb))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos: " + ex.Message);
            }
            finally
            {
                close();
            }

            return dataTable;
        }




    }
}
