using Microsoft.EntityFrameworkCore;
using dSalarial.Data.Mappings;
using dSalarial.Domain.Entities;

namespace dSalarial.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtividadeMap());
        }
    }
}