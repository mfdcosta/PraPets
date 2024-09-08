using Microsoft.Data.SqlClient;
using System.Data;

namespace PraPets.Repositories
{
    public class SqlServerConnection
    {
        private readonly string _connectionString;

        // Construtor para receber a string de conexão
        public SqlServerConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para abrir uma conexão com o banco de dados
        public SqlConnection GetConnection()
        {
            try
            {
                // Cria uma nova conexão
                SqlConnection connection = new SqlConnection(_connectionString);

                // Abre a conexão
                connection.Open();

                return connection;
            }
            catch (SqlException ex)
            {
                // Tratar exceções relacionadas ao SQL Server
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                // Tratar outras exceções
                Console.WriteLine("Erro geral: " + ex.Message);
                throw;
            }
        }

        // Método de exemplo para executar um comando no banco de dados
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rowsAffected;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public bool Exists(string query, Dictionary<string, object> parameters = null)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                connection.Open();
                object result = command.ExecuteScalar();
                exists = Convert.ToInt32(result) > 0;
            }

            return exists;
        }

      
    }
}
