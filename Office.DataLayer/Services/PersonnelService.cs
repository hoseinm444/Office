using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;
using Office.DataLayer.Context;
using Office.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace Office.DataLayer.Services
{
    public class PersonnelService : IPersonnelService
    {
        private IUnitOfWork _uow;
        private DbSet<Personnel> _PersonnelDBset;
        private DbSet<ChildOfPerosnnel>  _ChildDBset;
        public PersonnelService(IUnitOfWork uow)
        {
            _uow = uow;
            _PersonnelDBset = _uow.Set<Personnel>();
            _ChildDBset = _uow.Set<ChildOfPerosnnel>();
        }
        
        public string AmountOfChild(string PersonnelName , string personnelFamily)
        {
            if(!string.IsNullOrWhiteSpace(PersonnelName) && !string.IsNullOrWhiteSpace(personnelFamily))
            {
                var personnel = _PersonnelDBset.Where(p => p.Name == PersonnelName && 
                p.Family==personnelFamily).AsNoTracking().Select(p => p.Id)
                    .FirstOrDefault();
                if(personnel !=0)
                {
                    var child = _ChildDBset.Where(c => c.PersonnelId == personnel).Count();
                    return child.ToString();
                }
                else
                {
                    ///////there is no such personnel
                   return "We have no such Personnel";
                }
            }
            else
            {
                ///Plese enter something 
              return  "Plese enter something ";

            }

        }

        //public bool DeletePersonnel(Personnel personnel)
        //{
        //    ///////////// I use or instead of and 
        //    var personelId = _PersonnelDBset.Where(p => p.Name == personnel.Name &&  p.Family == personnel.Family ||
        //       p.NationalCode == personnel.NationalCode )
        //         .AsNoTracking().Select(p => p.Id).FirstOrDefault();
        //    if (personelId == default)
        //    {
        //        Console.WriteLine("We Have no such a Personnel for Delete .");
        //        return false;
        //    }
        //    var personnelentity = _PersonnelDBset.Where(p => p.Id == personelId)
        //        .FirstOrDefault();
        //    _PersonnelDBset.Attach(personnelentity).State = EntityState.Deleted;
        //    return true;
        //}


        public IList<Personnel> GetAllPersonnel()
        {
            return _PersonnelDBset.AsNoTracking().ToList();
        }

        public Personnel GetPersonnelById(int Id)
        {
            return _PersonnelDBset.Find(Id);
        }

        public Personnel InsertPersonnel(Personnel personnel)
        {
            _PersonnelDBset.Add(personnel);
            return personnel;
        }

        /// <summary>
        /// /for console I should write GetPersonnelForUpdate for api we need 
        /// other things
        /// </summary>
        /// <param name="GetPersonnelForUpdate"></param>
        /// <returns></returns>
        //public Personnel GetPersonnelForUpdate(Personnel personnel)
        //{
        //    var personnelId = _PersonnelDBset.Where(p => p.Name == personnel.Name && p.Family == personnel.Family ||
        //         p.NationalCode == personnel.NationalCode )
        //         .AsNoTracking().Select(p => p.Id).SingleOrDefault();
        //    if (personnelId == default)
        //    {
        //        Console.WriteLine("We Have no such a Personnel for Update .");
        //    }
        //    var personnelentity = _PersonnelDBset.Where(p => p.Id == personnelId)
        //        .SingleOrDefault();
        //    return personnelentity;
        //}

       //public Personnel GetPersonnelForUpdate(int Id)
       // {
       //     var personnelId = _PersonnelDBset.Where(p => p.Id == Id)
       //         .AsNoTracking().FirstOrDefault();
       //     if (personnelId == default)
       //     {
       //         Console.WriteLine("We Have no such a Personnel for Update .");
       //     }
       //     var personnelentity = _PersonnelDBset.Where(p => p.Id == personnelId.Id)
       //         .SingleOrDefault();
       //     return personnelentity;
       // }
        public bool UpdatePersonnel(Personnel personnel)
        {
           
            _PersonnelDBset.Attach(personnel).State = EntityState.Modified;
            return true;

        }

        public bool DeletePersonelById(int id)
        {
            ///////////// I use or instead of and 
            var personelId = _PersonnelDBset.Where(p => p.Id == id)
                 .AsNoTracking().Select(p => p.Id).FirstOrDefault();
            if (personelId == default)
            {
                Console.WriteLine("We Have no such a Personnel for Delete .");
                return false;
            }
            var personnelentity = _PersonnelDBset.Where(p => p.Id == personelId)
                .FirstOrDefault();
            _PersonnelDBset.Attach(personnelentity).State = EntityState.Deleted;
            return true;
        }
    }
}
