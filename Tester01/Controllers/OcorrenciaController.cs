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
            List<Ocorrencia> ocorrencias = await repository.BuscarOcorrencias();

            return ocorrencias.Count == 0 ? BadRequest("Ocorrencias não encontradas") : Ok(ocorrencias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Ocorrencia ocorrencia = await repository.PesquisarPorId(id);

            return  ocorrencia != null ? Ok(ocorrencia) : NotFound("Ocorrência não encontrada !!!!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ocorrencia ocorrenciaParaSerAdicionada)
        {
            ocorrenciaParaSerAdicionada.CreatedDate = DateTime.Now;
            repository.CriarOcorrencia(ocorrenciaParaSerAdicionada);

            return await repository.saveChangesAsync() ? Ok("Ocorrência adicionada com sucesso  !!!!")
                : BadRequest("Error ao salvar a ocorrência !!!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ocorrencia = await repository.PesquisarPorId(id);

            if(ocorrencia == null)
            {
                return NotFound("Ocorrencia não encontrada !!!!");
            }

            repository.DeletarOcorrencia(id);

            return await repository.saveChangesAsync() ? Ok("Ocorrência deletado com sucesso !!!") : 
                BadRequest("Error no sistema !!!");
        }
    }
}
