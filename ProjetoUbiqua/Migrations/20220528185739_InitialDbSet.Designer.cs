﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUbiqua.Context;

#nullable disable

namespace ProjetoUbiqua.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220528185739_InitialDbSet")]
    partial class InitialDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoUbiqua.Entities.Sala", b =>
                {
                    b.Property<int>("ID_Sala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Sala"), 1L, 1);

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<bool>("EstadoLuzes")
                        .HasColumnType("bit");

                    b.Property<int>("Lotacao")
                        .HasColumnType("int");

                    b.Property<string>("NomeSala")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Sala");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("ProjetoUbiqua.Entities.Sensor", b =>
                {
                    b.Property<int>("ID_Sensor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Sensor"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalaID_Sala")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Sensor");

                    b.HasIndex("SalaID_Sala");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("ProjetoUbiqua.Entities.Utilizador", b =>
                {
                    b.Property<int>("ID_Utilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Utilizador"), 1L, 1);

                    b.Property<bool>("Banido")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_admin")
                        .HasColumnType("bit");

                    b.Property<string>("NomeUtilizador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Utilizador");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("SalaUtilizador", b =>
                {
                    b.Property<int>("SalasID_Sala")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadoresID_Utilizador")
                        .HasColumnType("int");

                    b.HasKey("SalasID_Sala", "UtilizadoresID_Utilizador");

                    b.HasIndex("UtilizadoresID_Utilizador");

                    b.ToTable("SalaUtilizador");
                });

            modelBuilder.Entity("ProjetoUbiqua.Entities.Sensor", b =>
                {
                    b.HasOne("ProjetoUbiqua.Entities.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaID_Sala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("SalaUtilizador", b =>
                {
                    b.HasOne("ProjetoUbiqua.Entities.Sala", null)
                        .WithMany()
                        .HasForeignKey("SalasID_Sala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoUbiqua.Entities.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UtilizadoresID_Utilizador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}