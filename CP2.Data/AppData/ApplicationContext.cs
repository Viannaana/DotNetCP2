using Microsoft.EntityFrameworkCore;
using CP2.Domain.Entities;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<VendedorEntity> Vendedores { get; set; }
    public DbSet<FornecedorEntity> Fornecedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureFornecedorEntity(modelBuilder);
        ConfigureVendedorEntity(modelBuilder);
    }

    private void ConfigureFornecedorEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FornecedorEntity>(entity =>
        {
            entity.Property(e => e.Nome)
                  .HasColumnType("NVARCHAR2(100)")
                  .IsRequired();

            entity.Property(e => e.CNPJ)
                  .HasColumnType("NVARCHAR2(18)")
                  .IsRequired();

            entity.Property(e => e.Endereco)
                  .HasColumnType("NVARCHAR2(200)")
                  .IsRequired(false);

            entity.Property(e => e.Telefone)
                  .HasColumnType("NVARCHAR2(15)")
                  .IsRequired(false);

            entity.Property(e => e.Email)
                  .HasColumnType("NVARCHAR2(100)")
                  .IsRequired(false)
                  .HasMaxLength(100);

            entity.Property(e => e.CriadoEm)
                  .HasColumnType("DATE")
                  .IsRequired();
        });
    }

    private void ConfigureVendedorEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VendedorEntity>(entity =>
        {
            entity.Property(e => e.Nome)
                  .HasColumnType("NVARCHAR2(100)")
                  .IsRequired();

            entity.Property(e => e.Email)
                  .HasColumnType("NVARCHAR2(100)")
                  .IsRequired(false)
                  .HasMaxLength(100);

            entity.Property(e => e.Telefone)
                  .HasColumnType("NVARCHAR2(15)")
                  .IsRequired(false);

            entity.Property(e => e.DataNascimento)
                  .HasColumnType("DATE")
                  .IsRequired();

            entity.Property(e => e.Endereco)
                  .HasColumnType("NVARCHAR2(200)")
                  .IsRequired(false);

            entity.Property(e => e.DataContratacao)
                  .HasColumnType("DATE")
                  .IsRequired();

            entity.Property(e => e.ComissaoPercentual)
                  .HasColumnType("NUMBER")
                  .IsRequired();

            entity.Property(e => e.MetaMensal)
                  .HasColumnType("NUMBER")
                  .IsRequired();

            entity.Property(e => e.CriadoEm)
                  .HasColumnType("DATE")
                  .IsRequired();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuração para cenários fora do DI
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseOracle("sua_string_de_conexão");
        }
    }
}
