using Microsoft.EntityFrameworkCore;
using portarias.API.Models;

namespace portarias.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Atividade> Atividades { get; set; }
    }
}