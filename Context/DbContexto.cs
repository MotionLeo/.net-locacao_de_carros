using LocacaoDeCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoDeCarros.Context;

public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

    public DbSet<Carro> Carro { get; set; } = default!;
    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Configuracao> Configuracao { get; set; } = default!;
    public DbSet<Marca> Marca { get; set; } = default!;
    public DbSet<Modelo> Modelo { get; set; } = default!;
    public DbSet<Pedido> Pedido { get; set; } = default!;
} 