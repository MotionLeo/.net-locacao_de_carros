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

    [Column("id_carro")]
    public int IdCarro {get; set;}

    [Column("data_locacao", TypeName = "date")]

    public DateTime DataLocacao {get; set;} = default!;

    [Column("data_entrega", TypeName = "date")]
    public DateTime DataEntrega {get; set;} = default!;
}