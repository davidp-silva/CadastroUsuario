using Ds.Businness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data
{
    class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CPF).IsRequired()
                .HasColumnType("varchar(11)");
            builder.Property(p => p.Email).IsRequired()
                .HasColumnType("varchar(250)");
            builder.Property(p => p.Endereco).IsRequired()
                .HasColumnType("varchar(500)");
            builder.Property(p => p.Nome).IsRequired()
                .HasColumnType("varchar(250) ");
            builder.Property(p => p.Telefone).IsRequired()
                .HasColumnType("varchar(22) ");
        }
    }
}
