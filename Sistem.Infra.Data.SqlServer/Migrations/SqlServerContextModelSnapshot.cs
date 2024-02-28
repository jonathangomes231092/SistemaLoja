﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistem.Infra.Data.SqlServer.Contexts;

#nullable disable

namespace Sistem.Infra.Data.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sistem.Domain.Impl.Etities.RegisterProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.HasIndex("Quantidade");

                    b.HasIndex("Tipo");

                    b.HasIndex("Valor");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
