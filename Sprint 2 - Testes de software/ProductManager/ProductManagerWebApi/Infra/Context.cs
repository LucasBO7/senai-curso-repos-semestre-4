using Microsoft.EntityFrameworkCore;
using ProductManagerWebApi.Domains;

namespace ProductManagerWebApi.Infra
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se NÃO estiver configurado
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-3BKCPN3; initial catalog = ProductManager_tarde; User Id=sa; pwd=Senai@134; TrustServerCertificate = true;");
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}