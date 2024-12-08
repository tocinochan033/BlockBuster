using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    internal class IDHelper
    {
        private databaseConnection database = new databaseConnection();
        public int ObtenerIdPorNombre(string nombre, string tabla, string campoNombre)
        {
                database.open();
                string query = $"SELECT id_{tabla} FROM {tabla} WHERE {campoNombre} = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, database.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    object result = cmd.ExecuteScalar(); // Obtiene el primer valor de la primera fila (el ID)
                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Devuelve el ID encontrado
                    }
                    return -1; // Devuelve -1 si no se encuentra el ID
                }
        }

        public int ObtenerIdPorNombreYApellido(string nombre, string apellido, string tabla)
        {
            database.open();
            string query = $"SELECT id_{tabla} FROM {tabla} WHERE nombre = @nombre AND apellido = @apellido";
            using (SqlCommand cmd = new SqlCommand(query, database.getConnection()))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                object result = cmd.ExecuteScalar(); // Obtiene el primer valor de la primera fila (el ID)
                if (result != null)
                {
                    return Convert.ToInt32(result); // Devuelve el ID encontrado
                }
                return -1; // Devuelve -1 si no se encuentra el ID
            }
        }

        public List<KeyValuePair<string, int>> ObtenerListaDeActores()
        {
            List<KeyValuePair<string, int>> actores = new List<KeyValuePair<string, int>>();
            try
            {
                database.open();
                string query = "SELECT id_actor, CONCAT(nombre, ' ', apellido) AS NombreCompleto FROM actor";
                using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nombreCompleto = reader["NombreCompleto"].ToString();
                        int id = Convert.ToInt32(reader["id_actor"]);
                        actores.Add(new KeyValuePair<string, int>(nombreCompleto, id));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener lista de actores: " + ex.Message);
            }
            finally
            {
                database.close();
            }
            return actores;
        }
    }
}
