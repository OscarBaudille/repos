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
            string query = "SELECT ID_Especialidad, Nombre, ISNULL(Notas, '') AS Notas FROM dbo.Especialidades";
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
                        Nombre = reader.GetString(1),
                        Notas = reader.GetString(2)
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
                connection.Open(); SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    resultados.Add(new TuClaseInfo { Id = reader.GetInt32(0), Nombre = reader.GetString(1), Notas = reader.GetString(2) });
                }
            }
            return resultados;
        }
        public void ActualizarDatos(TuClaseInfo datos)
        {
            string query = "UPDATE dbo.Especialidades SET Nombre = @Nombre, Notas = @Notas WHERE ID_Especialidad = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", datos.Id);
                command.Parameters.AddWithValue("@Nombre", datos.Nombre);
                command.Parameters.AddWithValue("@Notas", datos.Notas);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarDatos(int id)
        {
            string query = "DELETE FROM dbo.Especialidades WHERE ID_Especialidad = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void InsertarDatos(TuClaseInfo datos)
        {
            string query = "INSERT INTO dbo.Especialidades (Nombre, Notas) VALUES (@Nombre, @Notas)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", datos.Nombre);
                command.Parameters.AddWithValue("@Notas", datos.Notas);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public class TuClaseInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Notas { get; set; }
    }
}
