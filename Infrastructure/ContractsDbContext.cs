using Domain;
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

        public DbSet<BillPointRule> BillPointRules { get; set; }

        public DbSet<OremZone> OremZones { get; set; }        

        public DbSet<EnergyLinkObjectToBillPoint> EnergyLinkObjectToBillPoints { get; set; }
        public DbSet<BillPointToMeterPoint> BillPointToMeterPoints { get; set; }
        public DbSet<RfSubjectToOremZone> RfSubjectToOremZones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=contract-manager;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseNpgsql("Host=localhost;Database=contract-manager;Username=TNE_USER;Password=123123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Contract>(entity => entity.HasOne(p => p.ContractKind).WithMany());

            // modelBuilder.Entity<RfSubject>().Property(bp => bp.Id).ValueGeneratedNever();
            // modelBuilder.Entity<Organization>().Property(bp => bp.Id).ValueGeneratedNever();
            //modelBuilder.Entity<BillPoint>().Property(bp => bp.Id).ValueGeneratedNever();

            // организация
            modelBuilder.Entity<Organization>()
                .HasOne(org => org.ParentOrganization)
                .WithMany(org => org.ChildOrganizations)
                .HasForeignKey(org => org.ParentOrganizationId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Organization>(entity => {
              //  entity.Property(rf => rf.ShortName).HasMaxLength(255).IsRequired();
              //  entity.Property(rf => rf.LongName).HasMaxLength(1024).IsRequired();
                entity.HasIndex(rf => rf.Guid).IsUnique();
            });


            // договор с доп. соглашениями
            modelBuilder.Entity<ContractDocument>(
                entity => {
                    entity.HasDiscriminator<int>("DocumentType")
                      .HasValue<Contract>(1)
                      .HasValue<SubContract>(2);

                    entity.HasIndex(cd => cd.Guid).IsUnique();
                    entity.Property(cd => cd.SignDate).HasColumnType("Date");
                    entity.Property(cd => cd.SActionDate).HasColumnType("Date");
                    entity.Property(cd => cd.EActionDate).HasColumnType("Date");
                }
            );
                       

           modelBuilder.Entity<Contract>(entity => {
                 entity.HasMany(p => p.SubContracts)
                 .WithOne(sub => sub.Contract)
                 .HasForeignKey(sub => sub.ContractDocumentId)
                 .OnDelete(DeleteBehavior.Restrict);

                 entity.Property(bp => bp.ContractKind).IsRequired();
                 entity.Property(bp => bp.DocumentNumber).IsRequired();
               
           });

            modelBuilder.Entity<ContractParticipant>(entity => entity.HasOne(p => p.Organization).WithMany());

            // другие сущности


            modelBuilder.Entity<RfSubject>(entity => { 
                entity.Property(rf => rf.Name).HasMaxLength(255);
                entity.Property(rf => rf.Code).HasMaxLength(50);
                entity.HasIndex(rf => rf.Guid).IsUnique();

            });
            modelBuilder.Entity<BillObject>(entity =>
            {
                entity.HasOne(p => p.RfSubject)
                .WithMany()
                .HasForeignKey(p => p.RfSubjectId).IsRequired();
                entity.HasIndex(rf => rf.Guid).IsUnique();
            });

           

            modelBuilder.Entity<BillObjectToEnergyLinkObject>(entity => {
                
                entity.HasKey(c => new { c.BillObjectId, c.EnergyLinkObjectId, c.SDate });
                entity.HasOne(link => link.BillObject).WithMany(bo => bo.BillObjectsToEnergyLinkObjects)
                .HasForeignKey(bo => bo.BillObjectId);
                entity.HasOne(link => link.EnergyLinkObject).WithMany(elo => elo.BillObjectsToEnergyLinkObjects)
                .HasForeignKey(bo => bo.EnergyLinkObjectId);
                entity.Property(cd => cd.SDate).HasColumnType("Date");
                entity.Property(cd => cd.EDate).HasColumnType("Date");
            });


            modelBuilder.Entity<BillPoint>(entity =>
            {
                entity.Property(bp => bp.Name).HasMaxLength(255);
                entity.HasIndex(bp => bp.Guid).IsUnique();
            });


            modelBuilder.Entity<BillSideToBillPoint>(entity => {
                entity.HasKey(c => new { c.EnergyLinkObjectId, c.BillPointId, c.SDate });
                
                entity.HasOne(link => link.EnergyLinkObject).WithMany(bs2bp => bs2bp.BillSideToBillPoints)
                .HasForeignKey(link => link.EnergyLinkObjectId);
                entity.HasOne(link => link.BillPoint).WithMany(elo => elo.BillSideToBillPoints)
                .HasForeignKey(bo => bo.BillPointId);
                entity.Property(cd => cd.SDate).HasColumnType("Date");
                entity.Property(cd => cd.EDate).HasColumnType("Date");
            });

            modelBuilder.Entity<EnergyLinkObjectToBillPoint>(entity => {

                entity.HasKey(c => new { c.Id });
                
                entity.HasOne(link => link.BillPoint).WithMany(bp => bp.EnergyLinkObjectsToBillPoints)
                .HasForeignKey(bo => bo.BillPointId);

                entity.HasOne(link => link.EnergyLinkObject).WithMany(elo => elo.EnergyLinkObjectsToBillPoints)
                .HasForeignKey(bo => bo.EnergyLinkObjectId);
                entity.Property(cd => cd.SDate).HasColumnType("Date");
                entity.Property(cd => cd.EDate).HasColumnType("Date");
            });

            modelBuilder.Entity<BillParam>(entity => {

                entity.HasKey(c => new { c.EnergyLinkObjectToBillPointId , c.BillParamType });

                entity.HasOne(link => link.EnergyLinkObjectToBillPoint).WithMany(bp => bp.BillParams)
                .HasForeignKey(bo => bo.EnergyLinkObjectToBillPointId);

               // entity.OwnsOne(bp => bp.BillParamTypeEnum);
                //entity.HasOne(link => link.BillParamType).WithMany();

            });


            modelBuilder.Entity<BillPointToMeterPoint>(entity => {

                entity.HasKey(c => new { c.BillPointId, c.MeterPointId, c.SDate });
                entity.HasOne(link => link.BillPoint).WithMany()
                .HasForeignKey(bo => bo.BillPointId);
                entity.HasOne(link => link.MeterPoint).WithMany()
                .HasForeignKey(bo => bo.MeterPointId);
                entity.Property(cd => cd.SDate).HasColumnType("Date");
                entity.Property(cd => cd.EDate).HasColumnType("Date");
            });

            modelBuilder.Entity<RfSubjectToOremZone>(entity => {

                entity.HasKey(c => new { c.RfSubjectId, c.OremZoneId, c.SDate });
                entity.HasOne(link => link.RfSubject).WithMany()
                .HasForeignKey(bo => bo.RfSubjectId);
                entity.HasOne(link => link.OremZone).WithMany()
                .HasForeignKey(bo => bo.OremZoneId);
              //  entity.Property(cd => cd.SDate).HasColumnType("Date");
              //  entity.Property(cd => cd.EDate).HasColumnType("Date");
            });

            modelBuilder.Entity<Organization>().HasData(
               new Organization[] {
                new Organization (1,Guid.Parse("76a1020f-a289-4950-858d-8cd08fbe8a27"),"ТНЭ","ТНЭ",OrganizationTypeEnum.SalesService),
                new Organization (2,Guid.Parse("fd177c31-2e33-489c-9e94-c109e5817396"),"КТК","КТК", OrganizationTypeEnum.Consumer),
                new Organization (3,Guid.Parse("b576d00e-f058-430c-92d2-4f7bdfc78956"),"Дружба","Дружба", OrganizationTypeEnum.Consumer),
                new Organization (4,Guid.Parse("c9e54849-c6f7-4ce8-adb1-7adfeaa2fd8d"),"Рога и копыта","Рога и копыта", OrganizationTypeEnum.None),
                new Organization (5,Guid.Parse("0b7e4010-f5e0-4736-aa61-007d3bf52cb1"),"Башкирэнерго","Башкирэнерго", OrganizationTypeEnum.SalesService | OrganizationTypeEnum.WireService),
               }
               );

            modelBuilder.Entity<BillPoint>().HasData(
              new BillPoint[] {
                new BillPoint (1,Guid.Parse("b8d40d2b-b9f2-463f-a3e8-467dcfbb48ea"),"ТП-1"),
                new BillPoint (2,Guid.Parse("2ee047a6-d87c-44b7-9e0e-f89bd526b1c3"),"ТП-2"),
                new BillPoint (3,Guid.Parse("235f7a97-ac8d-47c9-bead-528ff21a005f"),"ТП-3"),
              }
              );

            modelBuilder.Entity<RfSubject>().HasData(
            new RfSubject[] {
                new RfSubject (1,Guid.Parse("d8162092-2702-4ae3-a4f3-fbd1a85b6069"),"Астраханская область","30","12"),
                new RfSubject (2,Guid.Parse("99b12c1a-5df8-4f13-96b9-1a46f74ac7bc"),"Ставропольский край","26","07"),
                new RfSubject (3,Guid.Parse("8164c992-8c0b-42cb-bbb7-3b46461146cc"),"Краснодарский край","23","03"),
            }
            );

            modelBuilder.Entity<MeterPoint>().HasData(
           new MeterPoint[] {
                new MeterPoint (1,Guid.Parse("1245249a-4b74-48fd-b635-8c10f2660b55"),"ТИ-11"),
                new MeterPoint (2,Guid.Parse("f1156e79-9343-4598-95c9-57bb6e0b4dbd"),"ТИ-12"),
                new MeterPoint (3,Guid.Parse("4fe44c30-8ead-421a-8689-9c7be542b38e"),"ТИ-21"),
                new MeterPoint (4,Guid.Parse("0125044e-87d2-4e46-befe-c29ec4925608"),"ТИ-31"),
           }
           );

            modelBuilder.Entity<BillPointToMeterPoint>().HasData(
           new BillPointToMeterPoint[] {
                new BillPointToMeterPoint (1,1, DateTime.Now.Date,null),
                new BillPointToMeterPoint (1,2, DateTime.Now.Date,null),
                new BillPointToMeterPoint (2,3, DateTime.Now.Date,DateTime.Now.Date.AddDays(10)),
                new BillPointToMeterPoint (3,4, DateTime.Now.Date.AddDays(-10),null),
           }
           );

        }


        
    }

    
}
