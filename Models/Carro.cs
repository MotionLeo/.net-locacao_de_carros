using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("carros")]
public record Carro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar(100)")]
    [Required(ErrorMessage = "Nome do carro é obrigatório")]
    public string Nome { get;set; } = default!;

    [Column("id_modelo")]
    [ForeignKey("Modelo")]
    [Required(ErrorMessage = "Número do modelo é obrigatório")]
    public int IdModelo {get; set;}
    public Modelo? Modelo {get; set;}
    
    [Column("id_marca")]
    [ForeignKey("Marca")]
    [Required(ErrorMessage = "Número da marca é obrigatório")]
    public int IdMarca {get; set;}
    public Marca? Marca {get; set;}


}