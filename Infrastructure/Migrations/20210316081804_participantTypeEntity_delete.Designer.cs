﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ContractsDbContext))]
    [Migration("20210316081804_participantTypeEntity_delete")]
    partial class participantTypeEntity_delete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.BillObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("BillObjects");
                });

            modelBuilder.Entity("Domain.BillObjectToEnergyLinkObject", b =>
                {
                    b.Property<int>("BillObjectId")
                        .HasColumnType("int");

                    b.Property<int>("EnergyLinkObjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BillObjectId", "EnergyLinkObjectId", "SDate");

                    b.HasIndex("EnergyLinkObjectId");

                    b.ToTable("BillObjectToEnergyLinkObjects");
                });

            modelBuilder.Entity("Domain.BillParam", b =>
                {
                    b.Property<int>("EnergyLinkObjectToBillPointId")
                        .HasColumnType("int");

                    b.Property<int>("BillParamType")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("EnergyLinkObjectToBillPointId", "BillParamType");

                    b.ToTable("BillParam");
                });

            modelBuilder.Entity("Domain.BillPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TnePointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BillPoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "bp1",
                            TnePointId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "bp1",
                            TnePointId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "bp1",
                            TnePointId = 3
                        });
                });

            modelBuilder.Entity("Domain.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ContractKindId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContractKindId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Domain.ContractKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContractKinds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Договор энергоснабжения"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Договор купили-продажи"
                        });
                });

            modelBuilder.Entity("Domain.ContractParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ContractParticipants");
                });

            modelBuilder.Entity("Domain.EnergyLinkObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EnergyLinkObjects");
                });

            modelBuilder.Entity("Domain.EnergyLinkObjectToBillPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BillPointId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnergyLinkObjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BillPointId");

                    b.HasIndex("EnergyLinkObjectId");

                    b.ToTable("EnergyLinkObjectToBillPoint");
                });

            modelBuilder.Entity("Domain.FakeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FakeEntities");
                });

            modelBuilder.Entity("Domain.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ТНЭ"
                        },
                        new
                        {
                            Id = 2,
                            Name = "КТК"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Дружба"
                        });
                });

            modelBuilder.Entity("Domain.BillObject", b =>
                {
                    b.HasOne("Domain.Contract", null)
                        .WithMany("BillObjects")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.BillObjectToEnergyLinkObject", b =>
                {
                    b.HasOne("Domain.BillObject", "BillObject")
                        .WithMany("BillObjectsToEnergyLinkObjects")
                        .HasForeignKey("BillObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.EnergyLinkObject", "EnergyLinkObject")
                        .WithMany("BillObjectsToEnergyLinkObjects")
                        .HasForeignKey("EnergyLinkObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillObject");

                    b.Navigation("EnergyLinkObject");
                });

            modelBuilder.Entity("Domain.BillParam", b =>
                {
                    b.HasOne("Domain.EnergyLinkObjectToBillPoint", "EnergyLinkObjectToBillPoint")
                        .WithMany("BillParams")
                        .HasForeignKey("EnergyLinkObjectToBillPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnergyLinkObjectToBillPoint");
                });

            modelBuilder.Entity("Domain.Contract", b =>
                {
                    b.HasOne("Domain.ContractKind", "ContractKind")
                        .WithMany()
                        .HasForeignKey("ContractKindId");

                    b.Navigation("ContractKind");
                });

            modelBuilder.Entity("Domain.ContractParticipant", b =>
                {
                    b.HasOne("Domain.Contract", null)
                        .WithMany("ContractParticipants")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Domain.EnergyLinkObjectToBillPoint", b =>
                {
                    b.HasOne("Domain.BillPoint", "BillPoint")
                        .WithMany("EnergyLinkObjectsToBillPoints")
                        .HasForeignKey("BillPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.EnergyLinkObject", "EnergyLinkObject")
                        .WithMany("EnergyLinkObjectsToBillPoints")
                        .HasForeignKey("EnergyLinkObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillPoint");

                    b.Navigation("EnergyLinkObject");
                });

            modelBuilder.Entity("Domain.BillObject", b =>
                {
                    b.Navigation("BillObjectsToEnergyLinkObjects");
                });

            modelBuilder.Entity("Domain.BillPoint", b =>
                {
                    b.Navigation("EnergyLinkObjectsToBillPoints");
                });

            modelBuilder.Entity("Domain.Contract", b =>
                {
                    b.Navigation("BillObjects");

                    b.Navigation("ContractParticipants");
                });

            modelBuilder.Entity("Domain.EnergyLinkObject", b =>
                {
                    b.Navigation("BillObjectsToEnergyLinkObjects");

                    b.Navigation("EnergyLinkObjectsToBillPoints");
                });

            modelBuilder.Entity("Domain.EnergyLinkObjectToBillPoint", b =>
                {
                    b.Navigation("BillParams");
                });
#pragma warning restore 612, 618
        }
    }
}
