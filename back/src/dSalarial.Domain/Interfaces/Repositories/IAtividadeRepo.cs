using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSalarial.Domain.Entities;

namespace dSalarial.Domain.Interfaces
{
    public interface IAtividadeRepo : IGeralRepo
    {
        Task<Atividade[]> PegaTodasAsync();
        Task<Atividade> PegaPorIdAsync(int id);
        Task<Atividade> PegaPorTituloAsync(string titulo);
    }
}