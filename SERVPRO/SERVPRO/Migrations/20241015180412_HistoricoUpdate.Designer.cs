﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SERVPRO.Data;

#nullable disable

namespace SERVPRO.Migrations
{
    [DbContext(typeof(ServproDBContext))]
    [Migration("20241015180412_HistoricoUpdate")]
    partial class HistoricoUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SERVPRO.Models.Equipamento", b =>
                {
                    b.Property<string>("Serial")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Serial");

                    b.HasIndex("ClienteCPF");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("SERVPRO.Models.HistoricoOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrdemDeServicoId")
                        .HasColumnType("int");

                    b.Property<string>("TecnicoCPF")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrdemDeServicoId");

                    b.HasIndex("TecnicoCPF");

                    b.ToTable("HistoricosOS");
                });

            modelBuilder.Entity("SERVPRO.Models.OrdemDeServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClienteCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SerialEquipamento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TecnicoCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("dataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dataConclusao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteCPF");

                    b.HasIndex("SerialEquipamento");

                    b.HasIndex("TecnicoCPF");

                    b.ToTable("OrdensDeServico");
                });

            modelBuilder.Entity("SERVPRO.Models.Usuario", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("CPF");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("TipoUsuario").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SERVPRO.Models.Administrador", b =>
                {
                    b.HasBaseType("SERVPRO.Models.Usuario");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("SERVPRO.Models.Cliente", b =>
                {
                    b.HasBaseType("SERVPRO.Models.Usuario");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("SERVPRO.Models.Tecnico", b =>
                {
                    b.HasBaseType("SERVPRO.Models.Usuario");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasDiscriminator().HasValue("Tecnico");
                });

            modelBuilder.Entity("SERVPRO.Models.Equipamento", b =>
                {
                    b.HasOne("SERVPRO.Models.Cliente", "Cliente")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ClienteCPF")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SERVPRO.Models.HistoricoOS", b =>
                {
                    b.HasOne("SERVPRO.Models.OrdemDeServico", "OrdemDeServico")
                        .WithMany()
                        .HasForeignKey("OrdemDeServicoId");

                    b.HasOne("SERVPRO.Models.Tecnico", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoCPF");

                    b.Navigation("OrdemDeServico");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("SERVPRO.Models.OrdemDeServico", b =>
                {
                    b.HasOne("SERVPRO.Models.Cliente", "Cliente")
                        .WithMany("OrdensDeServico")
                        .HasForeignKey("ClienteCPF")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SERVPRO.Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("SerialEquipamento")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SERVPRO.Models.Tecnico", "Tecnico")
                        .WithMany("OrdensDeServico")
                        .HasForeignKey("TecnicoCPF")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cliente");

                    b.Navigation("Equipamento");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("SERVPRO.Models.Cliente", b =>
                {
                    b.Navigation("Equipamentos");

                    b.Navigation("OrdensDeServico");
                });

            modelBuilder.Entity("SERVPRO.Models.Tecnico", b =>
                {
                    b.Navigation("OrdensDeServico");
                });
#pragma warning restore 612, 618
        }
    }
}
