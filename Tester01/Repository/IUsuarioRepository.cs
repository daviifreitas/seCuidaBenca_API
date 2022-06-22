using Tester01.Models;

namespace Tester01.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> buscarUsuarios();

        Task<Usuario> buscarUsuario(int id);

        void AtualizarUsuario(Usuario usuario);

        void DeletarUsuario(Usuario usuario);
        void AdicionarUsuario(Usuario usuario);

        Task<bool> saveChangesAsync();
    }
}
