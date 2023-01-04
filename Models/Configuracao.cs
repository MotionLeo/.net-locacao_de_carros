using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("configuracoes")]
public record Configuracao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }

    [Required(ErrorMessage = "Nome da marca é obrigatório")]
    [Column("dias_de_locacao", TypeName = "varchar(100)")]
    public string DiasDeLocacao { get;set; } = default!;
}