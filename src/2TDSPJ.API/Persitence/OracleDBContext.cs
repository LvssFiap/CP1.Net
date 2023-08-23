using _2TDSPJ.API.Persitence.Models;
using Microsoft.EntityFrameworkCore;

namespace _2TDSPJ.API.Persitence
{
    public class OracleDBContext : DbContext
    {

        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<TipoQuarto> TipoQuartos { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public OracleDBContext(DbContextOptions<OracleDBContext> options) : base(options)
        {

        }


    }
}
