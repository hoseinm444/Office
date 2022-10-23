
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Office.DataLayer.Models;

namespace Office.DataLayer.Context
{
    public class OrganazationDbContext : DbContext, IUnitOfWork
    {
       //private IUnitOfWork uow;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               "Server=.\\SQL2019; Initial Catalog=OfficeDB;User Id=sa;Password=Aris3797;")
               .LogTo(Console.WriteLine,LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////////make composite key with 2 key of database 
            modelBuilder.Entity<PersonnelMainOffice>().HasKey(nameof(PersonnelMainOffice.PersonnelId), nameof(PersonnelMainOffice.OrganzationId));
            modelBuilder.Entity<Permission>().HasKey(p => new { p.OrganzationId, p.PersonnelId });

            //////make uniqe an attribute of table 
            modelBuilder.Entity<Personnel>()
                  .HasIndex(p => p.NationalCode)
                  .IsUnique();

            ///make gender as int type
            modelBuilder.Entity<Personnel>()
               .Property(c => c.PersonnelGender)
               .HasConversion<int>();

            ///////make gender as int type
            modelBuilder.Entity<ChildOfPerosnnel>()
              .Property(c => c.ChildGender)
              .HasConversion<int>();

            ////one to one relationship
            modelBuilder.Entity<Organazation>()
           .HasOne<PersonnelMainOffice>(p => p.PerosnnelMainOffice)
           .WithOne(p => p.Organiation)
           .HasForeignKey<PersonnelMainOffice>(p => p.OrganzationId);

            ///////many to many join 
            modelBuilder.Entity<Permission>()
            .HasOne<Organazation>(sc => sc.Organiation)
            .WithMany(s => s.Permissions)
             .HasForeignKey(sc => sc.OrganzationId);


            modelBuilder.Entity<Permission>()
                .HasOne<Personnel>(sc => sc.Personnel)
                .WithMany(s => s.Permissions)
                .HasForeignKey(sc => sc.PersonnelId);


        }

        

        public DbSet<ChildOfPerosnnel> Childern { get; set; }
        public DbSet<Organazation> Organzations { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PersonnelMainOffice> PersonnelMainOffices { get; set; }

        public void save()
        {
            try
            {
                SaveChanges();
            }
            catch(Exception ex)
            {
                var qdbg = ex.Message;
            }
            
        }
        //public void vvv()
        //{
        //    organzations.add
        //}


        //private IGenericRepository<ChildOfPerosnnel> _childopuow;
        //public IGenericRepository<ChildOfPerosnnel> ChildOfPerosnneluow
        //{
        //    get
        //    {SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_childOfPerosnnels_Personnels_PersonnelId". The conflict occurred in database "Orgnazation", table "dbo.Personnels", column 'Id'.
        //        if (this._childopuow == null)
        //        {
        //            this._childopuow = new GenericRepository<ChildOfPerosnnel>(this);
        //        }
        //        return _childopuow;
        //    }
        //}

        //private IGenericRepository<Orgnazation> _orgnazationuow;
        //public IGenericRepository<Orgnazation> Orgnazationuow
        //{
        //    get
        //    {
        //        if (this._orgnazationuow == null)
        //        {
        //            this._orgnazationuow = new GenericRepository<Orgnazation>(this);
        //        }
        //        return _orgnazationuow;
        //    }
        //}


        //private IGenericRepository<PersonnelMainOffice> _PersonnelMainOfficeuow;
        //public IGenericRepository<PersonnelMainOffice> PersonnelMainOfficeuow
        //{
        //    get
        //    {
        //        if (this._PersonnelMainOfficeuow == null)
        //        {
        //            this._PersonnelMainOfficeuow = new GenericRepository<PersonnelMainOffice>(this);
        //        }
        //        return _PersonnelMainOfficeuow;
        //    }
        //}

        //private IGenericRepository<Permission> _Permissionuow;
        //public IGenericRepository<Permission> Permissionuow
        //{
        //    get
        //    {
        //        if (this._Permissionuow == null)
        //        {
        //            this._Permissionuow = new GenericRepository<Permission>(this);
        //        }
        //        return _Permissionuow;
        //    }
        //}

        //private IGenericRepository<Personnel> _personneluow;
        //public IGenericRepository<Personnel> Personneluow
        //{
        //    get
        //    {
        //        if (this._personneluow == null)
        //        {
        //            this._personneluow = new GenericRepository<Personnel>(this);
        //        }
        //        return _personneluow;
        //    }
        //}

        //public void Dispose()
        //{
        //    uow.Dispose();
        //}

    }
}
