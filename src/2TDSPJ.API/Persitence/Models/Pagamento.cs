using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2TDSPJ.API.Persitence.Models
{
    [Table("TB_PAGAMENTO")]
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagamentoId { get; set; }

        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}
