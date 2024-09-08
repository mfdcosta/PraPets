using PraPets.Dtos;
using PraPets.Models;
using System.Collections.Generic;
using System.Data;

namespace PraPets.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlServerConnection _sqlServerConnection;

        public UsuarioRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _sqlServerConnection = new SqlServerConnection(connectionString);
        }

        public Usuario atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDto buscar(int id)
        {
            // SQL para buscar um usuário pelo id
            string query = "SELECT u.id, u.Nome, u.Email, e.rua, e.numero, e.Cidade, e.Estado, e.CEP, t.Nome AS TipoUsuario " +
                           "FROM Usuario u " +
                           "INNER JOIN Endereco e ON u.idEndereco = e.id " +
                           "INNER JOIN TipoUsuario t ON u.idTipoUsuario = t.id " +
                           "WHERE u.id = @id";

            // Parâmetros para prevenir SQL Injection
            var parameters = new Dictionary<string, object>
        {
            { "@id", id }
        };

            // Executa a consulta e obtém o resultado
            DataTable resultado = _sqlServerConnection.ExecuteQuery(query, parameters);

            if (resultado.Rows.Count > 0)
            {
                // Preenche e retorna o objeto Usuario
                DataRow row = resultado.Rows[0];
                return new UsuarioDto
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["Nome"].ToString(),
                    Email = row["Email"].ToString(),
                    Endereco = row["rua"].ToString(),
                    Numero = row["numero"].ToString(),
                    Cidade = row["Cidade"].ToString(),
                    Estado = row["Estado"].ToString(),
                    CEP = row["CEP"].ToString(),
                    TipoUsuario = row["TipoUsuario"].ToString()
                };
            }
            else
            {
                return null; // Nenhum registro encontrado
            }
        }

        public Usuario criar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void deletar(int id)
        {
            // SQL para deletar um usuário pelo id
            string query = "DELETE FROM Usuario WHERE id = @id";

            // Parâmetros para prevenir SQL Injection
            var parameters = new Dictionary<string, object>
            {
                { "@id", id }
            };

            // Executar a consulta de deleção
            _sqlServerConnection.ExecuteNonQuery(query, parameters);
        }

        public bool existe(int id)
        {
            // SQL para deletar um usuário pelo id
            string query = "select id FROM Usuario WHERE id = @id";

            // Parâmetros para prevenir SQL Injection
            var parameters = new Dictionary<string, object>
            {
                { "@id", id }
            };

            // Executar a consulta de deleção
            return _sqlServerConnection.Exists(query, parameters);
        }

        public List<UsuarioDto> listarTodos()
        {
            string query = "select u.id, u.Nome, u.Email, e.rua, e.numero, e.Cidade, e.Estado, e.CEP, t.Nome AS TipoUsuario FROM Usuario u INNER JOIN Endereco e ON u.idEndereco = e.id INNER JOIN TipoUsuario t ON u.idTipoUsuario = t.id";
            var resultado = _sqlServerConnection.ExecuteQuery(query);

            List<UsuarioDto> usuarios = new List<UsuarioDto>();

            // Exibe os resultados da consulta
            foreach (DataRow row in resultado.Rows)
            {
                UsuarioDto usuario = new UsuarioDto();
                usuario.Id = Convert.ToInt32(row["id"]);
                usuario.Nome = row["Nome"].ToString();
                usuario.Email = row["email"].ToString();
                usuario.Endereco = row["rua"].ToString();
                usuario.Numero = row["numero"].ToString();
                usuario.Cidade = row["Cidade"].ToString();
                usuario.Estado = row["Estado"].ToString();
                usuario.CEP = row["CEP"].ToString();
                usuario.TipoUsuario = row["TipoUsuario"].ToString();

                usuarios.Add(usuario);
            }

            return usuarios;
        }
    }
}
