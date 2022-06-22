using Microsoft.AspNetCore.Mvc;
using seCuidaBenca.Repository.Interfaces;

namespace seCuidaBenca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaRepository repository;

        public OcorrenciaController(IOcorrenciaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ocorrencias = repository.BuscarOcorrencias();

            return await ocorrencias == null ? BadRequest("Ocorrencias não encontradas") : Ok(ocorrencias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ocorrencia = repository.PesquisarPorId(id);

            return await ocorrencia != null ? Ok(ocorrencia) : NotFound("Ocorrência não encontrada !!!!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ocorrencia ocorrenciaParaSerAdicionada)
        {
            repository.CriarOcorrencia(ocorrenciaParaSerAdicionada);

            return await repository.saveChangesAsync() ? Ok("Ocorrência adicionada com sucesso  !!!!")
                : BadRequest("Error ao salvar a ocorrência !!!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Ocorrencia ocorrenciaParaAlteracao , int id)
        {
            var ocorrenciaBanco = await repository.PesquisarPorId(id);

            if(ocorrenciaParaAlteracao == null )
            {
                return NotFound("A ocorrência não foi encontrada !!!!");
            }

            ocorrenciaBanco.DescricaoDaOcorrencia = ocorrenciaParaAlteracao.DescricaoDaOcorrencia ?? ocorrenciaBanco.DescricaoDaOcorrencia;

            if (ocorrenciaBanco.Id_DoUsuario == ocorrenciaParaAlteracao.Id_DoUsuario)
            {
                ocorrenciaBanco.Id_DoUsuario = ocorrenciaParaAlteracao.Id_DoUsuario;
            } 
            else
            {
                ocorrenciaBanco.Id_DoUsuario = ocorrenciaBanco.Id_DoUsuario;
            }
            
            ocorrenciaParaAlteracao.Id_Ocorrencia = id;

            repository.CriarOcorrencia(ocorrenciaParaAlteracao);

            return await repository.saveChangesAsync() ? Ok("Ocorrência adicionada com sucesso !!!") : BadRequest("Error ao adicionar ocorrência !!!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ocorrencia = await repository.PesquisarPorId(id);

            if(ocorrencia == null)
            {
                return NotFound("Ocorrencia não encontrada !!!!");
            }

            repository.DeletarOcorrencia(ocorrencia);

            return Ok("Ocorrência deletada com sucesso !!!!");
        }
    }
}
