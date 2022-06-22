using Microsoft.AspNetCore.Mvc;
using Tester01.Models;
using Tester01.Repository;

namespace Tester01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await repository.buscarUsuario(id);

            return usuario != null ? Ok(usuario)
                : NotFound("Usuário não encontrado !!!!!");
        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await repository.buscarUsuarios();

            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {

            repository.AdicionarUsuario(usuario);

            return await repository.saveChangesAsync() ? Ok("Usuário adicionado com sucesso !!!!") 
                : BadRequest("Error ao salvar usuário !!!");
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Usuario usuario, int id)
        {
            var u1 = await repository.buscarUsuario(id);

            if(usuario == null)
            {
                return NotFound("Usuario não encontrado !!!");
            }

            u1.Nome = usuario.Nome ?? u1.Nome;
            u1.dataNascimento = usuario.dataNascimento != new DateTime() ? usuario.dataNascimento : u1.dataNascimento;

            repository.AdicionarUsuario(usuario);

            return await repository.saveChangesAsync() ? Ok("Usuário alterado com sucesso !!!") : BadRequest("Error ao fazer alteração no usuário !!!");
        }

        [HttpDelete("{id}")]
       
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await repository.buscarUsuario(id);

            if(usuario != null)
            {
                repository.DeletarUsuario(usuario);

                return await repository.saveChangesAsync() ? Ok("Usuário deletado com sucesso !!!") : BadRequest("Error no sistema !!!");
            }

            return NotFound("Usuário não encontrado para ser deletado !!!");

        }
    }
}
