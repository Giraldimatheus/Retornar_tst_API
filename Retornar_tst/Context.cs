using Microsoft.EntityFrameworkCore;
using Retornar_tst.Models;

namespace Retornar_tst
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NumeroSorteio> NumerosSorteio { get; set; }

        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string connectionString = "Data Source=MAT\\MSSQLSERVER1;Initial Catalog=RETORNAR;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(connectionString);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<NumeroSorteio>()
                .HasIndex(ns => ns.Numero)
                .IsUnique();

        }

    }
}
