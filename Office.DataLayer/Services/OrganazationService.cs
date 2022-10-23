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
    public class OrganazationService : IOrganazationService
    {

        private IUnitOfWork _uow;
        private DbSet<Organazation> _orgnazationDBset;
        private DbSet<PersonnelMainOffice> _pmoDBset;
      //  private DbSet<Personnel> _personnelDBset;
        public OrganazationService(IUnitOfWork uow)
        {
            _uow = uow;
            _orgnazationDBset = _uow.Set<Organazation>();
            _pmoDBset = _uow.Set<PersonnelMainOffice>();
        }
        //public bool DeleteOrganazation(Organazation orgnazation)
        //{
        //    var orgIdforPMO = _orgnazationDBset.Where(o => o.Code == orgnazation.Code &&
        //      o.Name == orgnazation.Name).Select(o => o.Id).SingleOrDefault();
        //    /////in personnelMainOffice table we have organazationId and PersonnelId it means 
        //    ///organazation of that personnel so if PersonnelMainOfiice.orgazationId equal to
        //    ///Organazation.Id we access right personnelId.
        //    if (orgIdforPMO == default)
        //    {
        //        Console.WriteLine("We don't have such Organazation for Delete.");
        //        return false;
        //    }

        //    var pmoid = _pmoDBset.Where(o => o.OrganzationId == orgIdforPMO).Select(p => p.PersonnelId)
        //        .SingleOrDefault();
        //    var org = _orgnazationDBset.Where(o => o.Name == orgnazation.Name && o.Code == orgnazation.Code &&
        //     o.PersonnelMainOfficeId == pmoid).SingleOrDefault();
        //    _orgnazationDBset.Attach(org).State = EntityState.Deleted;
        //    return true;
        //}
        public bool DeleteOrganazationById(int id)
        {
             var orgId=_orgnazationDBset.Where(o=>o.Id==id)
                .AsNoTracking().Select(o => o.Id).SingleOrDefault();
            if (orgId == default)
            {
                Console.WriteLine("We don't have such Organazation for Delete.");
                return false;
            }
            var org = _orgnazationDBset.Find(id);
            _orgnazationDBset.Attach(org).State = EntityState.Deleted;
            return true;
        }

        public IList<Organazation> GetAllOrganazation()
        {
            return _orgnazationDBset.AsNoTracking().ToList();
        }

        public Organazation GetOrganazationById(int Id)
        {
            return _orgnazationDBset.Find(Id);
        }

        public void InsertOrganazation(Organazation orgnazation)
        {
            _orgnazationDBset.Add(orgnazation);
        }

        public int ParrentOrganazationId(string orgName, string orgCode)
        {
            var parrentId = _orgnazationDBset.Where(o => o.Code == orgCode && o.Name == orgName)
                .AsNoTracking().Select(o => o.Id).SingleOrDefault();
            if (parrentId != default)
            {
                return parrentId;
            }
            else
            {
                return 0;
            }
        }

        public bool UpdateOrganazation(int Id , Organazation org)
        {
            var orgid = _orgnazationDBset.Find(Id);
            if( (!string.IsNullOrWhiteSpace(org.Name)) && (!string.IsNullOrWhiteSpace(org.Code)) 
                && org.PersonnelMainOfficeId>=0)
            {
                if (orgid == default)
                {
                    Console.WriteLine("We can't find such Organazation for Update!!!");
                    return false;
                }
                orgid.Code = org.Code;
                orgid.Name = org.Name;
                orgid.ParrentOfficeId = org.ParrentOfficeId;
                orgid.PersonnelMainOfficeId = org.PersonnelMainOfficeId;
                _orgnazationDBset.Attach(orgid).State = EntityState.Modified;
                return true;
            }
           else
            {
                Console.WriteLine("your datafor Updating Organazation is invalid !!!");
                return false;
            }
        }
        //public int PersonnelMainOfficeInfo(string name, string family, string nationalcode)
        //{
        //    var persId = _personnelDBset.Where(o => o.Name == name && o.Family == family ||
        //      o.NationalCode == nationalcode).Select(o => o.Id).SingleOrDefault();
        //    if(persId==default)
        //    {
        //        Console.WriteLine("we can't find such a personnel.");
        //    }
        //    var pmo = _pmoDBset.Where(pmo => pmo.PersonnelId == persId).Select(pmo => pmo.PersonnelId)
        //        .SingleOrDefault();

        //}
        public string ParrentOrganazationName(int parrentId)
        {
            var nameorg = _orgnazationDBset.Where(o => o.Id == parrentId).AsNoTracking().Select(o => o.Name).SingleOrDefault();
            return nameorg;
        }
        public string ParrentOrganazationCode(int parrentId)
        {
            var orgorg = _orgnazationDBset.Where(o => o.Id == parrentId).AsNoTracking().Select(o => o.Code).SingleOrDefault();
            return orgorg;
        }
    }
}
