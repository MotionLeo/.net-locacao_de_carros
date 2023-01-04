using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("pedidos")]
public record Pedido
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [Column("id_cliente")]
    public int IdCliente { get;set; }

    [Column("carro")]
    public int Carro {get; set;}

    [Column("data_locacao", TypeName = "date")]

    public string DataLocacao {get; set;} = default!;

    [Column("data_entrega", TypeName = "date")]
    public string DataEntrega {get; set;} = default!;
}