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

        public async Task<Ocorrencia> AlterarOcorrenciaPorId(int id)
        {
            var ocorrencia = PesquisarPorId(id);

            if(ocorrencia != null)
            {
                context.Remove(PesquisarPorId(id));
                context.Add(ocorrencia);
            }
            return await ocorrencia;
        }

        public async Task<IEnumerable<Ocorrencia>> BuscarOcorrencias()
        {
            return await context.Ocorrencia.ToListAsync();
        }

        public void CriarOcorrencia(Ocorrencia ocorrenciaParaSerCriada)
        {
            if(ocorrenciaParaSerCriada != null)
            {
                context.Add(ocorrenciaParaSerCriada);
            }
        }

        public void DeletarOcorrencia(Ocorrencia ocorrencia)
        {
            context.Remove(ocorrencia);
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
