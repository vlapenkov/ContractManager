﻿using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums;

namespace Infrastructure
{
    public class ContractsDbContext : DbContext
    {
        private readonly IMediator _mediator;
        public ContractsDbContext() { }
        public ContractsDbContext(DbContextOptions<ContractsDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //public DbSet<ContractKind> ContractKinds { get; set; }        
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<SubContract> SubContracts { get; set; }
        public DbSet<ContractParticipant> ContractParticipants { get; set; }
          
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<BillObject> BillObjects { get; set; }
        public DbSet<RfSubject> RfSubjects { get; set; }
        public DbSet<EnergyLinkObject> EnergyLinkObjects { get; set; }
        public DbSet<BillObjectToEnergyLinkObject> BillObjectToEnergyLinkObjects { get; set; }

        public DbSet<BillSideToBillPoint> BillSideToBillPoints { get; set; }

        public DbSet<BillPoint> BillPoints { get; set; }

        public DbSet<BillParam> BillParams { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=contract-manager;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseNpgsql("Host=localhost;Database=contract-manager;Username=TNE_USER;Password=123123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Contract>(entity => entity.HasOne(p => p.ContractKind).WithMany());

            modelBuilder.Entity<RfSubject>().Property(bp => bp.Id).ValueGeneratedNever();
            modelBuilder.Entity<Organization>().Property(bp => bp.Id).ValueGeneratedNever();
            modelBuilder.Entity<BillPoint>().Property(bp => bp.Id).ValueGeneratedNever();

            // договор с доп. соглашениями
            modelBuilder.Entity<ContractDocument>()
              .HasDiscriminator<int>("DocumentType")
                .HasValue<Contract>(1)
                .HasValue<SubContract>(2);

            modelBuilder.Entity<Contract>().Property(bp => bp.ContractKind).IsRequired();
            modelBuilder.Entity<Contract>().Property(bp => bp.DocumentNumber).IsRequired();

             modelBuilder.Entity<Contract>(entity => entity.HasMany(p => p.SubContracts)
             .WithOne(sub=>sub.Contract).HasForeignKey(sub=>sub.ContractDocumentId).OnDelete(DeleteBehavior.Restrict));

            

            // другие сущности


            modelBuilder.Entity<RfSubject>(entity => { 
                entity.Property(rf => rf.Name).HasMaxLength(255);
                entity.Property(rf => rf.Code).HasMaxLength(50);
            
            });
            modelBuilder.Entity<BillObject>(entity => entity.HasOne(p => p.RfSubject)
            .WithMany().HasForeignKey(p=>p.RfSubjectId).IsRequired());

            // modelBuilder.Entity<ContractParticipant>(entity => entity.HasOne(p => p.ParticipantType).WithMany());

            modelBuilder.Entity<ContractParticipant>(entity => entity.HasOne(p => p.Organization).WithMany());

           

            modelBuilder.Entity<BillObjectToEnergyLinkObject>(entity => {
                
                entity.HasKey(c => new { c.BillObjectId, c.EnergyLinkObjectId, c.SDate });
                entity.HasOne(link => link.BillObject).WithMany(bo => bo.BillObjectsToEnergyLinkObjects)
                .HasForeignKey(bo => bo.BillObjectId);
                entity.HasOne(link => link.EnergyLinkObject).WithMany(elo => elo.BillObjectsToEnergyLinkObjects)
                .HasForeignKey(bo => bo.EnergyLinkObjectId);
            });

            modelBuilder.Entity<BillPoint>().Property(bp => bp.Id).ValueGeneratedNever();


            modelBuilder.Entity<BillSideToBillPoint>(entity => {
                entity.HasKey(c => new { c.EnergyLinkObjectId, c.BillPointId, c.SDate });
                
                entity.HasOne(link => link.EnergyLinkObject).WithMany(bs2bp => bs2bp.BillSideToBillPoints)
                .HasForeignKey(link => link.EnergyLinkObjectId);
                entity.HasOne(link => link.BillPoint).WithMany(elo => elo.BillSideToBillPoints)
                .HasForeignKey(bo => bo.BillPointId);
            });

            modelBuilder.Entity<EnergyLinkObjectToBillPoint>(entity => {

                entity.HasKey(c => new { c.Id });
                
                entity.HasOne(link => link.BillPoint).WithMany(bp => bp.EnergyLinkObjectsToBillPoints)
                .HasForeignKey(bo => bo.BillPointId);

                entity.HasOne(link => link.EnergyLinkObject).WithMany(elo => elo.EnergyLinkObjectsToBillPoints)
                .HasForeignKey(bo => bo.EnergyLinkObjectId);
            });

            modelBuilder.Entity<BillParam>(entity => {

                entity.HasKey(c => new { c.EnergyLinkObjectToBillPointId , c.BillParamType });

                entity.HasOne(link => link.EnergyLinkObjectToBillPoint).WithMany(bp => bp.BillParams)
                .HasForeignKey(bo => bo.EnergyLinkObjectToBillPointId);

               // entity.OwnsOne(bp => bp.BillParamTypeEnum);
                //entity.HasOne(link => link.BillParamType).WithMany();

            });

            
            modelBuilder.Entity<Organization>().HasData(
               new Organization[] {
                new Organization (1,"ТНЭ",OrganizationTypeEnum.SalesService),
                new Organization (2,"КТК", OrganizationTypeEnum.Consumer),
                new Organization (3,"Дружба", OrganizationTypeEnum.Consumer),
                new Organization (4,"Рога и копыта", OrganizationTypeEnum.None),
                new Organization (5,"Башкирэнерго", OrganizationTypeEnum.SalesService | OrganizationTypeEnum.WireService),
               }
               );

            modelBuilder.Entity<BillPoint>().HasData(
              new BillPoint[] {
                new BillPoint (1,"bp1",1),
                new BillPoint (2,"bp1",2),
                new BillPoint (3,"bp1",3),
              }
              );

            modelBuilder.Entity<RfSubject>().HasData(
            new RfSubject[] {
                new RfSubject (1,"Астраханская область","30","12"),
                new RfSubject (2,"Ставропольский край","26","07"),
                new RfSubject (3,"Краснодарский край","23","03"),
            }
            );

        }


        
    }

    
}
