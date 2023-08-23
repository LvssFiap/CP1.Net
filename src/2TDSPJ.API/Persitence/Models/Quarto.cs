using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2TDSPJ.API.Persitence.Models
{
    [Table("TB_QUARTO")]
    public class Quarto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuartoId { get; set; }

        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public string NumeroQuarto { get; set; }

        public Decimal PrecoPorNoite { get; set; }

        // Relação muitos-para-muitos com a classe TipoQuarto
        public virtual ICollection<TipoQuarto> TipoQuartos { get; set; }
    }
}
