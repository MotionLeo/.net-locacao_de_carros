using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("modelos")]
public record Modelo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }

    [Required(ErrorMessage = "Nome do modelo é obrigatório")]
    [Column("nome", TypeName = "varchar(100)")]
    public string Nome { get;set; } = default!;

    [Column("id_marca")]
    [ForeignKey("Marca")]
    public int IdMarca { get;set; } = default!;
    public Marca? Marca { get;set; }
}