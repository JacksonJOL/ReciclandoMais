﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReciclaMais.Data;

#nullable disable

namespace ReciclaMais.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ReciclaMais.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContribuinteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Medidas")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PesoAproximado")
                        .HasColumnType("REAL");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContribuinteId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("ReciclaMais.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator().HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ReciclaMais.Models.Contribuinte", b =>
                {
                    b.HasBaseType("ReciclaMais.Models.Usuario");

                    b.HasDiscriminator().HasValue("Contribuinte");
                });

            modelBuilder.Entity("ReciclaMais.Models.Material", b =>
                {
                    b.HasOne("ReciclaMais.Models.Contribuinte", "Contribuinte")
                        .WithMany("Materiais")
                        .HasForeignKey("ContribuinteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contribuinte");
                });

            modelBuilder.Entity("ReciclaMais.Models.Contribuinte", b =>
                {
                    b.Navigation("Materiais");
                });
#pragma warning restore 612, 618
        }
    }
}
