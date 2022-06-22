using Microsoft.EntityFrameworkCore;
using Tester01.Data;
using Tester01.Models;

namespace Tester01.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext usuarioContext;

        public UsuarioRepository(UsuarioContext usuarioContext)
        {
            this.usuarioContext = usuarioContext;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarioContext.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            usuarioContext.Update(usuario);
        }

        public async Task<Usuario> buscarUsuario(int id)
        {
            return await usuarioContext.usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Usuario>> buscarUsuarios()
        {
            return await usuarioContext.usuarios.ToListAsync();
        }

        public void DeletarUsuario(Usuario usuario)
        {
            usuarioContext.Remove(usuario);

        }

        public async Task<bool> saveChangesAsync()
        {
            return await usuarioContext.SaveChangesAsync() > 0;
        }
    }
}
