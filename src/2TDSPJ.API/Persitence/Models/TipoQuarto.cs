using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2TDSPJ.API.Persitence.Models
{
    [Table("TB_TIPOQUARTO")]
    public class TipoQuarto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoQuartoId { get; set; }
        public string Descricao { get; set; }

        // Relação muitos-para-muitos com a classe Quarto
        public virtual ICollection<Quarto> Quartos { get; set; }
    }
}
