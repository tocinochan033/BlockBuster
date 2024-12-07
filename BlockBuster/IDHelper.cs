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

    }
}
