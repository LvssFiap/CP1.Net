using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2TDSPJ.API.Persitence.Models
{
    [Table("TB_RESERVA")]
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }

        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public DateTime DataSaida { get; set; }
        [Required]
        public Decimal ValorTotal { get; set; }

        // Relação um-para-muitos com a classe Pagamento
        public virtual ICollection<Pagamento> Pagamentos { get; set; }

        [ForeignKey("Hospede")]
        public int HospedeId { get; set; }
        public virtual Hospede Hospede { get; set; }

        [ForeignKey("Quarto")]
        public int QuartoId { get; set; }
        public virtual Quarto Quarto { get; set; }
    }
}
