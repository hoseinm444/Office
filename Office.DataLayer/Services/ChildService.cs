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
    public class ChildService : IChildService
    {
        private IUnitOfWork _uow;

        private DbSet<ChildOfPerosnnel> _childDBset;
        private DbSet<Personnel> _personnelDbset;
        public ChildService(IUnitOfWork uow)
        {
            _uow = uow;
            _childDBset = _uow.Set<ChildOfPerosnnel>();
            _personnelDbset = _uow.Set<Personnel>();
        }

        //public bool DeleteChild(ChildOfPerosnnel Child)
        //{
        //    var childId = _childDBset.Where(p => p.Name == Child.Name || p.Family == Child.Family ||
        //      p.NationalCode == Child.NationalCode || p.ChildGender == Child.ChildGender)
        //        .AsNoTracking().Select(p => p.Id).SingleOrDefault();
        //    if (childId ==default)
        //    {
        //        Console.WriteLine("We Have no such a child .");
        //        return false;
        //    }
        //    var childentity=_childDBset.Where(p=>p.Id==childId).SingleOrDefault();
        //    _childDBset.Attach(childentity).State = EntityState.Deleted;
        //   // _childDBset.Remove(childentity);
        //    return true;
        //}
        public bool DeleteChildById(int Id)
        {
            var childId = _childDBset.Where(p => p.Id ==Id)
                .AsNoTracking().Select(p => p.Id).SingleOrDefault();
            if (childId == default)
            {
                Console.WriteLine("We Have no such a child .");
                return false;
            }
            var childentity = _childDBset.Where(p => p.Id == childId).SingleOrDefault();
            _childDBset.Attach(childentity).State = EntityState.Deleted;
            // _childDBset.Remove(childentity);
            return true;
        }
        public IList<ChildOfPerosnnel> GetAllChild()
        {
            return  _childDBset.AsNoTracking().ToList();
        }

        public ChildOfPerosnnel GetChildById(int Id)
        {
            return _childDBset.Find(Id);
        }

        public void InsertChild(ChildOfPerosnnel Child)
        {
            _childDBset.Add(Child);
        }

        public int PersonnelIdByName(string fathername)
        {
            var fatherInPersonel = _personnelDbset.Where(p => p.Name== fathername || p.Family==fathername ).AsNoTracking()
                .Select(p => p.Id).SingleOrDefault();
            
           
            if (fatherInPersonel == default)
            {
                //var fatherID = _personnelDbset.Where(p => p.Id == _childDBset.Select(p => p.PersonnelId)
                //.SingleOrDefault()).Select(p => p.Id).SingleOrDefault();
                //return fatherID;
                Console.WriteLine("                  There is no such Personnel in this orgnazation.");
            }
            return fatherInPersonel;
        }

        public bool UpdateChild(ChildOfPerosnnel Child)
        {
           
           // var childentity = GetChildById(childId);
            _childDBset.Attach(Child).State = EntityState.Modified;
            /////above update is better
            ///// _childDBset.Update
            return true;
        }


       public ChildOfPerosnnel GetChildUpdate(string name = "", string family = "", string fathername="", string Nationalcode = "")
        {
         var child = _childDBset.Where(p => p.Name == name && p.Family == family &&
              p.NationalCode == Nationalcode || p.FatherName == fathername).SingleOrDefault();
            if(child ==default)
            {
                Console.WriteLine("We can't find your child that you enter  .");
            }
            return child;
        }



    }


}
