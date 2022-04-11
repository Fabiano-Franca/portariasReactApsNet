using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSalarial.Domain.Entities;

namespace dSalarial.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> AdicionarAtividade(Atividade model);
        Task<Atividade> AtualizarAtividade(Atividade model);
        Task<bool> DeletarAtividade(int model);
        Task<bool> ConcluirAtividade(Atividade model);
        Task<Atividade[]> PegarTodasAtividadesAsync();
        Task<Atividade> PegarAtividadePorIdAsync(int atividadeId);

    }
}