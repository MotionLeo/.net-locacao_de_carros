using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("configuracoes")]
public record Configuracao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }

    [Required(ErrorMessage = "Esse campo é obrigatório")]
    [Column("dias_de_locacao", TypeName = "date")]
    public DateTime DiasDeLocacao { get;set; } = default!;
}