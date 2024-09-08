using PraPets.Dtos;
using PraPets.Models;

namespace PraPets.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario criar(Usuario usuario);
        UsuarioDto buscar(int id);
        void deletar(int id);
        Usuario atualizar(Usuario usuario);
        bool existe(int id);
        List<UsuarioDto> listarTodos();
    }
}
