using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Webcombo
{
    public class DataAccess
    {
        private string connectionString = "Server=OBA1\\SQLEXPRESS; Database=Kairos; Integrated Security=True;";

        public List<TuClaseInfo> ObtenerDatos()
        {
            string query = "SELECT ID_Especialidad, Nombre FROM dbo.Especialidades";
            List<TuClaseInfo> resultados = new List<TuClaseInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    resultados.Add(new TuClaseInfo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }

            return resultados;
        }

        public List<TuClaseInfo> ObtenerDatosPorId(int id)
        {
            string query = "SELECT ID_Especialidad, Nombre, ISNULL(Notas, '') FROM dbo.Especialidades WHERE ID_Especialidad = @Id";
            List<TuClaseInfo> resultados = new List<TuClaseInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    resultados.Add(new TuClaseInfo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Notas = reader.GetString(2)
                    });
                }
            }

            return resultados;
        }
    }

    public class TuClaseInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Notas { get; set; }
    }
}
