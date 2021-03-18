﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ContractsDbContext))]
    partial class ContractsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("RfSubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("RfSubjectId");

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

                    b.ToTable("BillParams");
                });

            modelBuilder.Entity("Domain.BillPoint", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

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

                    b.Property<int>("ParticipantType")
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

            modelBuilder.Entity("Domain.Entities.BillSideToBillPoint", b =>
                {
                    b.Property<int>("EnergyLinkObjectId")
                        .HasColumnType("int");

                    b.Property<int>("BillPointId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeSide")
                        .HasColumnType("int");

                    b.HasKey("EnergyLinkObjectId", "BillPointId", "SDate");

                    b.HasIndex("BillPointId");

                    b.ToTable("BillSideToBillPoints");
                });

            modelBuilder.Entity("Domain.Entities.ContractDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EActionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SActionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SignDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ContractDocument");

                    b.HasDiscriminator<int>("ContractType");
                });

            modelBuilder.Entity("Domain.Entities.RfSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("RfSubjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "12",
                            Name = "Астраханская область"
                        },
                        new
                        {
                            Id = 2,
                            Code = "07",
                            Name = "Ставропольский край"
                        },
                        new
                        {
                            Id = 3,
                            Code = "03",
                            Name = "Краснодарский край"
                        });
                });

            modelBuilder.Entity("Domain.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ТНЭ",
                            OrganizationType = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "КТК",
                            OrganizationType = 4
                        },
                        new
                        {
                            Id = 3,
                            Name = "Дружба",
                            OrganizationType = 4
                        },
                        new
                        {
                            Id = 4,
                            Name = "Рога и копыта",
                            OrganizationType = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Башкирэнерго",
                            OrganizationType = 3
                        });
                });

            modelBuilder.Entity("Domain.Contract", b =>
                {
                    b.HasBaseType("Domain.Entities.ContractDocument");

                    b.Property<int>("ContractKind")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Domain.Entities.SubContract", b =>
                {
                    b.HasBaseType("Domain.Entities.ContractDocument");

                    b.Property<int>("ContractDocumentId")
                        .HasColumnType("int");

                    b.HasIndex("ContractDocumentId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Domain.BillObject", b =>
                {
                    b.HasOne("Domain.Contract", null)
                        .WithMany("BillObjects")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.RfSubject", "RfSubject")
                        .WithMany()
                        .HasForeignKey("RfSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RfSubject");
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

            modelBuilder.Entity("Domain.Entities.BillSideToBillPoint", b =>
                {
                    b.HasOne("Domain.BillPoint", "BillPoint")
                        .WithMany("BillSideToBillPoints")
                        .HasForeignKey("BillPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.EnergyLinkObject", "EnergyLinkObject")
                        .WithMany("BillSideToBillPoints")
                        .HasForeignKey("EnergyLinkObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillPoint");

                    b.Navigation("EnergyLinkObject");
                });

            modelBuilder.Entity("Domain.Entities.SubContract", b =>
                {
                    b.HasOne("Domain.Contract", "Contract")
                        .WithMany("SubContracts")
                        .HasForeignKey("ContractDocumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Domain.BillObject", b =>
                {
                    b.Navigation("BillObjectsToEnergyLinkObjects");
                });

            modelBuilder.Entity("Domain.BillPoint", b =>
                {
                    b.Navigation("BillSideToBillPoints");

                    b.Navigation("EnergyLinkObjectsToBillPoints");
                });

            modelBuilder.Entity("Domain.EnergyLinkObject", b =>
                {
                    b.Navigation("BillObjectsToEnergyLinkObjects");

                    b.Navigation("BillSideToBillPoints");

                    b.Navigation("EnergyLinkObjectsToBillPoints");
                });

            modelBuilder.Entity("Domain.EnergyLinkObjectToBillPoint", b =>
                {
                    b.Navigation("BillParams");
                });

            modelBuilder.Entity("Domain.Contract", b =>
                {
                    b.Navigation("BillObjects");

                    b.Navigation("ContractParticipants");

                    b.Navigation("SubContracts");
                });
#pragma warning restore 612, 618
        }
    }
}
