using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dSalarial.Domain.Interfaces
{
    public interface IGeralRepo
    {
        void Adicionar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Deletar<T>(T entity) where T : class;
        void DeletarVarias<T>(T[] entity) where T : class;
        Task<bool> SalvarMudançasAsync();

    }
}