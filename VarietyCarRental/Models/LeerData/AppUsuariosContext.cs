using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;

namespace VarietyCarRental.Models.LeerData
{
    public class AppUsuariosContext: DbContext
    {
        private const string connectionString = @"Data Source=DANIELSPC\SQLEXPRESS;Initial Catalog=Rent_a_Car;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Usuarios> Usuarios { get; set; }
    }


}
