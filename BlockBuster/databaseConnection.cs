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

        public SqlConnection getConnection()
        {
            return connectiondb;
        }
    }
}
