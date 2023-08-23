using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2TDSPJ.API.Persitence.Models
{
    [Table("TB_HOSPEDE")]
    public class Hospede
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HospedeId { get; set; }

        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public string Sobrenome { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Relação um-para-muitos com a classe Reserva
        public virtual ICollection<Reserva> Reservas { get; set; }


    }
}
