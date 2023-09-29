using Microsoft.EntityFrameworkCore;

namespace Laboratorio3.Services.Clienti
{
    public class ClientiDbContext : DbContext
    {
        public ClientiDbContext()
        {
        }

        public ClientiDbContext(DbContextOptions<ClientiDbContext> options) : base(options) { }

        public DbSet<Cliente> Clienti { get; set; }
    }
}
