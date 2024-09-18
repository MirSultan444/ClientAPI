using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Database
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
