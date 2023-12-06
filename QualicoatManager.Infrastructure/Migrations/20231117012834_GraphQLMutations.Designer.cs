﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QualicoatManager.Infrastructure.Context;

#nullable disable

namespace QualicoatManager.Infrastructure.Migrations
{
    [DbContext(typeof(QualicoatManagerDbContext))]
    [Migration("20231117012834_GraphQLMutations")]
    partial class GraphQLMutations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QualicoatManager.Domain.Entities.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssessmentsGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Expected")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Success")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentsGroupId");

                    b.ToTable("Assesments");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.AssessmentsGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssesmentsGroup");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.BaseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.Formulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssesmentsGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormulationsFolderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssesmentsGroupId");

                    b.HasIndex("FormulationsFolderId");

                    b.ToTable("Formulations");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.FormulationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("FormulationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RawMaterialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormulationId");

                    b.HasIndex("RawMaterialId");

                    b.ToTable("FormulationItems");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.FormulationsFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormulationsFolders");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.RawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RawMaterials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 0,
                            Description = "Polyester TGIC 93/3 ratio from Reichhold.",
                            Name = "Resina M-8930"
                        },
                        new
                        {
                            Id = 2,
                            Category = 0,
                            Description = "Regular tgic made in China",
                            Name = "TGIC"
                        },
                        new
                        {
                            Id = 3,
                            Category = 0,
                            Description = "Regular agent made in China",
                            Name = "Flow agent"
                        },
                        new
                        {
                            Id = 4,
                            Category = 0,
                            Description = "Basic TiO2",
                            Name = "TiO2"
                        },
                        new
                        {
                            Id = 5,
                            Category = 0,
                            Description = "Brasil Minas",
                            Name = "BaSO4"
                        },
                        new
                        {
                            Id = 6,
                            Category = 0,
                            Description = "Carbon Powder",
                            Name = "Negro de Fumo"
                        });
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.Assessment", b =>
                {
                    b.HasOne("QualicoatManager.Domain.Entities.AssessmentsGroup", null)
                        .WithMany("Assesments")
                        .HasForeignKey("AssessmentsGroupId");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.Formulation", b =>
                {
                    b.HasOne("QualicoatManager.Domain.Entities.AssessmentsGroup", "AssesmentsGroup")
                        .WithMany()
                        .HasForeignKey("AssesmentsGroupId");

                    b.HasOne("QualicoatManager.Domain.Entities.FormulationsFolder", null)
                        .WithMany("Formulations")
                        .HasForeignKey("FormulationsFolderId");

                    b.Navigation("AssesmentsGroup");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.FormulationItem", b =>
                {
                    b.HasOne("QualicoatManager.Domain.Entities.Formulation", null)
                        .WithMany("Items")
                        .HasForeignKey("FormulationId");

                    b.HasOne("QualicoatManager.Domain.Entities.RawMaterial", "RawMaterial")
                        .WithMany()
                        .HasForeignKey("RawMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RawMaterial");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("QualicoatManager.Domain.Entities.BaseUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.AssessmentsGroup", b =>
                {
                    b.Navigation("Assesments");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.BaseUser", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.Formulation", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("QualicoatManager.Domain.Entities.FormulationsFolder", b =>
                {
                    b.Navigation("Formulations");
                });
#pragma warning restore 612, 618
        }
    }
}
