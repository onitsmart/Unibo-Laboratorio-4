using Laboratorio3.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio3.Services.Clienti
{
    public class ClientiDbContext : DbContext
    {
        public ClientiDbContext()
        {
        }

        public ClientiDbContext(DbContextOptions<ClientiDbContext> options) : base(options)
        {
            // ES2 SOLO PER ESERCITAZIONE. E' UN DATABASE IN MEMORY
            DataGenerator.InitializeClienti(this);
        }

        public DbSet<Cliente> Clienti { get; set; }
    }
}
