using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSalarial.Data.Context;
using dSalarial.Domain.Interfaces;

namespace dSalarial.Data.Repositories
{
    public class GeralRepo : IGeralRepo
    {
        private readonly DataContext _context;
        public GeralRepo(DataContext context)
        {
            _context = context;
            
        }
        public void Adicionar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeletarVarias<T>(T[] entitys) where T : class
        {
            _context.Remove(entitys);
        }

        public async Task<bool> SalvarMudançasAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}