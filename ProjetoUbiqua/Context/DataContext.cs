using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Utilizador>Utilizador { get; set; }
        public DbSet<Sala> Sala { get; set; }   
        public DbSet<Sensor> Sensor { get; set; }
    }
}
