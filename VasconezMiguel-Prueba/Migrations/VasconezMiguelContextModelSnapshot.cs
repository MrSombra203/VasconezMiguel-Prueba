﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace VasconezMiguel_Prueba.Migrations
{
    [DbContext(typeof(VasconezMiguelContext))]
    partial class VasconezMiguelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VasconezMiguel_Prueba.Models.Celular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Celular");
                });

            modelBuilder.Entity("VasconezMiguel_Prueba.Models.MVasconez", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Compra")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCelular")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("peso")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdCelular");

                    b.ToTable("MVasconez");
                });

            modelBuilder.Entity("VasconezMiguel_Prueba.Models.MVasconez", b =>
                {
                    b.HasOne("VasconezMiguel_Prueba.Models.Celular", "Celular")
                        .WithMany()
                        .HasForeignKey("IdCelular")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celular");
                });
#pragma warning restore 612, 618
        }
    }
}
