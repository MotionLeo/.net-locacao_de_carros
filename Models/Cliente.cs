using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("clientes")]
public record Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [Column("nome", TypeName = "varchar(100)")]
    public string Nome { get;set; } = default!;

    [Column("email", TypeName = "varchar(50)")]
    public string? Email {get; set;}

    [Column("telefone", TypeName = "varchar(11)")]
    public string? Telefone {get; set;}

    [Required(ErrorMessage = "Endereço é obrigatório")]
    [Column("endereco", TypeName = "text")]
    public string Endereco {get; set;} = default!;

}