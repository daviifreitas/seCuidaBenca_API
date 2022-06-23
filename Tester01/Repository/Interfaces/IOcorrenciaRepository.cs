namespace seCuidaBenca.Repository.Interfaces
{
    public interface IOcorrenciaRepository
    {
        Task<Ocorrencia> PesquisarPorId(int id); 
        Task<List<Ocorrencia>> BuscarOcorrencias();
        void CriarOcorrencia(Ocorrencia ocorrenciaParaSerCriada);
        void DeletarOcorrencia(int idDaOcorrencia);
        Task<bool> saveChangesAsync();
    }
}
