using Microsoft.EntityFrameworkCore;
using seCuidaBenca.Data;
using seCuidaBenca.Repository.Interfaces;

namespace seCuidaBenca.Repository
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly OcorrenciaContext context;

        public OcorrenciaRepository(OcorrenciaContext context)
        {
            this.context = context;
        }

        public async Task<List<Ocorrencia>> BuscarOcorrencias()
        {
            List<Ocorrencia> ocorrencias = await context.Ocorrencia.ToListAsync();

            return ocorrencias;
        }

        public void CriarOcorrencia(Ocorrencia ocorrenciaParaSerCriada)
        {
            if(ocorrenciaParaSerCriada != null)
            {
                context.Add(ocorrenciaParaSerCriada);
            }
        }

        public void DeletarOcorrencia(int idDaOcorrencia)
        {
            Ocorrencia ocorrenciaParaSerDeletada = PesquisarPorId(idDaOcorrencia).Result;
            context.Remove(ocorrenciaParaSerDeletada);
        }

        public async Task<Ocorrencia> PesquisarPorId(int id)
        {
            return await context.Ocorrencia.Where(x => x.Id_Ocorrencia == id).FirstOrDefaultAsync();
        }

        public async Task<bool> saveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
