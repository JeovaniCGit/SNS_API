using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SNS.Models;

namespace SNS.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<BaixaMedica> BaixasMedicas { get; set; }
    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<HistoricoLaboral> HistoricoLaboral { get; set; }

    public virtual DbSet<Instituição> Instituicoes { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TipoDeSetor> TiposDeSetor { get; set; }

    public virtual DbSet<TipoDeUtilizador> TiposDeUtilizador { get; set; }

    public virtual DbSet<Utilizador> Utilizadores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Especial__3213E83FF9DC20A7");

            entity.ToTable("Especialidade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descri)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descri");
        });

        modelBuilder.Entity<HistoricoLaboral>(entity =>
        {
            entity.HasKey(e => new { e.Instituiçãoid, e.Medicoid }).HasName("PK__Historic__6E11538B37C7ADFC");

            entity.ToTable("Historico_Laboral");

            entity.Property(e => e.DataFim).HasColumnType("datetime");
            entity.Property(e => e.DataInicio).HasColumnType("datetime");

            entity.HasOne(d => d.Instituição)
                .WithMany()
                .HasForeignKey(d => d.Instituiçãoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKHistorico_735488");

            entity.HasOne<Medico>()
                .WithMany(p => p.HistoricoLaborals)
                .HasForeignKey(d => d.Medicoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKHistorico_875756");
        });

        modelBuilder.Entity<Instituição>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Institui__3213E83FA39E834C");

            entity.ToTable("Instituição");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descri)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descri");

            entity.HasOne(d => d.TipoDeSetor).WithMany(p => p.Instituiçãos)
                .HasForeignKey(d => d.TipoDeSetorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKInstituiçã171310");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medico__3213E83FE9155587");

            entity.ToTable("Medico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NMedico).HasColumnName("nMedico");

            entity.HasOne(d => d.Especialidade)
                .WithMany()
                .HasForeignKey(d => d.Especialidadeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMedico588860");

            entity.HasOne<Utilizador>()
                .WithMany(p => p.Medicos)
                .HasForeignKey(d => d.Utilizadorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMedico808163");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3213E83FC7F14CDD");

            entity.ToTable("Paciente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EntidadePatronal)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("entidadePatronal");
            entity.Property(e => e.NumeroSns).HasColumnName("numeroSNS");
            entity.Property(e => e.Profissao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profissao");

            entity.HasOne<Utilizador>()
                .WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.Utilizadorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPaciente149628");
        });

        modelBuilder.Entity<TipoDeSetor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoDeSe__3213E83F3BE0EEE6");

            entity.ToTable("TipoDeSetor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descri)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descri");
        });

        modelBuilder.Entity<TipoDeUtilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoDeUt__3213E83FCD81D941");

            entity.ToTable("TipoDeUtilizador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descri)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descri");
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Utilizad__3213E83F4B2A429E");
            entity.HasQueryFilter(e => e.IsActive);

            entity.ToTable("Utilizador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Morada)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("morada");
            entity.Property(e => e.NTelefone).HasColumnName("nTelefone");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.NumeroCc).HasColumnName("numeroCC");
            entity.Property(e => e.Sexo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sexo");

            entity.HasOne(d => d.TipoDeUtilizador).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.TipoDeUtilizadorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUtilizador773635");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
