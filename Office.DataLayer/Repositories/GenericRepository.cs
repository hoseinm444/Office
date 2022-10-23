using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Office.DataLayer.Context;
using Office.DataLayer.Models;

namespace Office.DataLayer.Repository
{
   //public  class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
   // {
   //    //IUnitOfWork _context=new OrganazationDbContext();
   //     private DbSet<TEntity> _dbset;

   //     public GenericRepository(IUnitOfWork context)
   //     {
   //         //_context = context;
   //         _dbset = context.Set<TEntity>();
   //     }



   //     public virtual void Delete(TEntity entity)
   //     {
   //         //if (_context.Entry(entity).State == EntityState.Detached)
   //         //{
   //         //    _dbset.Attach(entity);
   //         //}

   //         _dbset.Remove(entity);
   //     }


   //     public virtual IList<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
   //     {
   //         IQueryable<TEntity> query = _dbset;

   //         if (where != null)
   //         {
   //             query = query.Where(where);
   //         }

   //         if (orderby != null)
   //         {
   //             query = orderby(query);
   //         }

   //         if (includes != "")
   //         {
   //             foreach (string include in includes.Split(','))
   //             {
   //                 query = query.Include(include);
   //             }
   //         }

   //         return query.ToList();
   //     }

   //     public IList<TEntity> GetAll()
   //     {
   //         return _dbset.ToList();
   //     }

   //     public virtual TEntity GetById(int id)
   //     {
   //         return _dbset.Find(id);
   //     }

   //     public virtual void Insert(TEntity entity)
   //     {
   //         _dbset.Add(entity);
   //     }

   //     public virtual void Update(TEntity entity)
   //     {
   //         _dbset.Attach(entity);
   //         //_context.Entry(entity).State = EntityState.Modified;
   //     }
   // }
}

