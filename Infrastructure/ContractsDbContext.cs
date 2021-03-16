﻿using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        public DbSet<ContractKind> ContractKinds { get; set; }        
        public DbSet<Contract> Contracts { get; set; }        
        public DbSet<ContractParticipant> ContractParticipants { get; set; }
       // public DbSet<ParticipantType> ParticipantTypes { get; set; }        
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<BillObject> BillObjects { get; set; }
        public DbSet<EnergyLinkObject> EnergyLinkObjects { get; set; }
        public DbSet<BillObjectToEnergyLinkObject> BillObjectToEnergyLinkObjects { get; set; }

        public DbSet<BillPoint> BillPoints { get; set; }

      //  public DbSet<BillParam> BillParams { get; set; }



       // public DbSet<FakeEntityLink> FakeEntityLinks { get; set; }


        public DbSet<FakeEntity> FakeEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=contract-manager;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contract>(entity => entity.HasOne(p => p.ContractKind).WithMany());

           // modelBuilder.Entity<ContractParticipant>(entity => entity.HasOne(p => p.ParticipantType).WithMany());

            modelBuilder.Entity<ContractParticipant>(entity => entity.HasOne(p => p.Organization).WithMany());

           

            modelBuilder.Entity<BillObjectToEnergyLinkObject>(entity => {
                
                entity.HasKey(c => new { c.BillObjectId, c.EnergyLinkObjectId, c.SDate });
                entity.HasOne(link => link.BillObject).WithMany(bo => bo.BillObjectsToEnergyLinkObjects)
                .HasForeignKey(bo => bo.BillObjectId);
                entity.HasOne(link => link.EnergyLinkObject).WithMany(elo => elo.BillObjectsToEnergyLinkObjects)
                .HasForeignKey(bo => bo.EnergyLinkObjectId);
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

          




            modelBuilder.Entity<ContractKind>().HasData(
                new ContractKind[] {
                new ContractKind (1,"Договор энергоснабжения"),
                new ContractKind (2,"Договор купили-продажи")
                }
                );

            //modelBuilder.Entity<ParticipantType>().HasData(
            //    new ParticipantType[] {
            //    new ParticipantType (1,"Продавец электроэнергии"),
            //    new ParticipantType (2,"Покупатель электроэнергии"),
            //    new ParticipantType (3,"Население"),
            //    new ParticipantType (4,"Организация оказывающая услуги населению"),
            //    }
            //    );

            modelBuilder.Entity<Organization>().HasData(
               new Organization[] {
                new Organization (1,"ТНЭ"),
                new Organization (2,"КТК"),
                new Organization (3,"Дружба"),
               }
               );

            modelBuilder.Entity<BillPoint>().HasData(
              new BillPoint[] {
                new BillPoint (1,"bp1",1),
                new BillPoint (2,"bp1",2),
                new BillPoint (3,"bp1",3),
              }
              );
            /*
            modelBuilder.Entity<BillParamTypeEnum>().HasData(
             new BillParamTypeEnum[] {
                BillParamTypeEnum.PriceCategory,
                BillParamTypeEnum.VoltageTarifLevel,
                BillParamTypeEnum.Sign,
                BillParamTypeEnum.VolumeCategory
             }
             ); */
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

    
}
