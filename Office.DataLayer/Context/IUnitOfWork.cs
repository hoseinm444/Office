using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Repository;
using Office.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Office.DataLayer.Context
{
   public  interface IUnitOfWork : IDisposable 
    {
         DbSet<TEntity> Set<TEntity>() where TEntity : class;


        //public DbSet<ChildOfPerosnnel> childOfPerosnnels { get; set; }
        //public DbSet<Orgnazation> organzations { get; set; }
        //public DbSet<Personnel> Personnels { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        //public DbSet<PersonnelMainOffice> PersonnelMainOffices { get; set; }


        void save();

        //IGenericRepository<ChildOfPerosnnel> ChildOfPerosnneluow { get; }
        //IGenericRepository<Personnel> Personneluow { get; }
        //IGenericRepository<Permission> Permissionuow { get; }
        //IGenericRepository<PersonnelMainOffice> PersonnelMainOfficeuow { get; }
        //IGenericRepository<Orgnazation> Orgnazationuow { get; }
    }
}
