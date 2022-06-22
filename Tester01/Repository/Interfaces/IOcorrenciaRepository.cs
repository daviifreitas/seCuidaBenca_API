﻿namespace seCuidaBenca.Repository.Interfaces
{
    public interface IOcorrenciaRepository
    {
        Task<Ocorrencia> PesquisarPorId(int id); 
        Task<IEnumerable<Ocorrencia>> BuscarOcorrencias();
        void CriarOcorrencia(Ocorrencia ocorrenciaParaSerCriada);
        Task<Ocorrencia> AlterarOcorrenciaPorId(int id);
        void DeletarOcorrencia(Ocorrencia ocorrencia);
        Task<bool> saveChangesAsync();
    }
}
