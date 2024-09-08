using PraPets.Dtos;
using PraPets.Exceptions;
using PraPets.Models;
using PraPets.Repositories;

namespace PraPets.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        // Construtor que recebe o repositório
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        // Método para criar um novo usuário
        public Usuario criarUsuario(Usuario usuario)
        {
            if (usuario == null) 
            {
                throw new Exception("Usuário não pode ser nulo.");
            }
            if (usuarioRepository.existe(usuario.getId())) {
                throw new UsuarioJaExisteException("Usuário com esse ID já existe.");
            }
            return usuarioRepository.criar(usuario);
        }

        public UsuarioDto buscarUsuarioPorId(int id)
        {
            if (!usuarioRepository.existe(id)) {
                throw new UsuarioNaoExisteException("Usuário com esse ID não existe.");
            }
                return usuarioRepository.buscar(id);
        }

        // Método para atualizar um usuário existente
        public Usuario atualizarUsuario(Usuario usuario)
        {
            if (usuario == null || !usuarioRepository.existe(usuario.getId())) {
                throw new UsuarioNaoExisteException("Usuário não encontrado ou inválido.");
            }
                return usuarioRepository.atualizar(usuario);
        }
        // Método para deletar um usuário pelo ID

        public void deletarUsuario(int id)
        {
            if (!usuarioRepository.existe(id)) {
                throw new UsuarioNaoExisteException("Usuário com esse ID não existe.");
            }
            usuarioRepository.deletar(id);
        }

        // Método para listar todos os usuários
        public List<UsuarioDto> listarTodosUsuarios()
        {
            return usuarioRepository.listarTodos();
        }
    }
}
