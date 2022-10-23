using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;
using Office.DataLayer.Context;
using Office.DataLayer.Repository;
using Office.DataLayer.DTO_Class;
using Microsoft.EntityFrameworkCore;

namespace Office.DataLayer.Services
{
    public class PersonnelMainOfficeService : IPersonnelMainOfficeService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Personnel> _personnelDBset;
        private readonly DbSet<Organazation> _organazationDBset;
        private readonly DbSet<PersonnelMainOffice> _pmo;
        private readonly DbSet<PersonnelMainOfficeDTO> _pmoDTO;
        public PersonnelMainOfficeService(IUnitOfWork uow)
        {
            _uow = uow;
            _personnelDBset = _uow.Set<Personnel>();
            _organazationDBset = _uow.Set<Organazation>();
            _pmo = _uow.Set<PersonnelMainOffice>();
            _pmoDTO = _uow.Set<PersonnelMainOfficeDTO>();
        }
        //public bool DeletePersonnelMainOffice(PersonnelMainOffice pmo)
        //{
        //  var perId=GetPersonnel(pmo.PersonnelId);
        //}

        public bool DeletePersonnelMainOffice(int personnelId , int orgId)
        {
            
            var pmoId = _pmo.FirstOrDefault(p=>p.PersonnelId == personnelId && p.OrganzationId== orgId);
                //_pmo.Where(p => p.PersonnelId == perId && p.OrganzationId == orgId)
                //.SingleOrDefault();
            if (pmoId==default)
            {
                Console.WriteLine("We don't have this Personel Main Office.");
                return false;
            }
            if(pmoId.PersonnelId != personnelId || pmoId.OrganzationId !=orgId)
            {
                Console.WriteLine("We can't delete this Personel Main Office.");
                return false;
            }
            _pmo.Attach(pmoId).State = EntityState.Deleted;
            return true;
        }

        //why I wrote this func ?
        //I write it becuse we need to have information of personnel and org with 
        //ecach other and we cathch it with Id
        public PersonnelMainOfficeDTO GetPMOInfoById(int personnelId, int organazationId)
        {
            try
            {
                var org = _organazationDBset.Find(organazationId);
                var personnel = _personnelDBset.Find(personnelId);

                if (org == null || personnel == null)
                {
                    throw new ArgumentNullException
                        ("your organazationId and PersonnelId isn't correct");
                }
                else
                {

                    var pmodto = new PersonnelMainOfficeDTO()
                    {
                        PersonnelNameDTO = personnel.Name,
                        PersonnelFamilyDTO = personnel.Family,
                        NationalCodeDTO = personnel.NationalCode,
                        OrgNameDTO = org.Name,
                        OrgCodeDTO = org.Code
                    };
                    return pmodto;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException ("We don't have such a PersonnelMainOffice Informations");
            }
        }
        //public PersonnelMainOfficeDTO GetPMOInfo(PersonnelMainOffice pmo)
        //{
        //    //var perName =_personnelDBset.Where(p=>p.Id==pmo.PersonnelId).Select(p=>p.Name).SingleOrDefault();
        //    //var perFamily = _personnelDBset.Where(p => p.Id == pmo.PersonnelId).Select(p => p.Family).SingleOrDefault();
        //    //var perNC = _personnelDBset.Where(p => p.Id == pmo.PersonnelId).Select(p => p.NationalCode).SingleOrDefault();

        //    var x = _personnelDBset.Where(p => p.Id == pmo.PersonnelId)
        //        .AsNoTracking()
        //        .Select(p => new { p.Name, p.Family, p.NationalCode }).SingleOrDefault();

        //    if (string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Family) && string.IsNullOrEmpty(x.NationalCode)/*perName==null && perFamily==null && perNC==null*/)
        //    {
        //        return default;
        //    }
        //    var org = _organazationDBset.Where(p => p.Id == pmo.OrganzationId)
        //       .AsNoTracking()
        //       .Select(p => new { p.Name, p.Code }).SingleOrDefault();

        //    if (string.IsNullOrEmpty(org.Name) && string.IsNullOrEmpty(org.Code))
        //    {
        //        return default;
        //    }
        //    var dto = new PersonnelMainOfficeDTO
        //    {
        //        PersonnelNameDTO = x.Name,
        //        PersonnelFamilyDTO = x.Family,
        //        NationalCodeDTO = x.NationalCode,
        //        OrgCodeDTO = org.Code,
        //        OrgNameDTO = org.Name
        //    };
        //    return dto;
        //}

        public IList<PersonnelMainOffice> GetAllPMO()
        {
            return _pmo.AsNoTracking().ToList();
        }
        public PersonnelMainOffice GetPMOById(int personnelId, int organazationId)
        {
            try
            {
                var pmo = _pmo.Find(personnelId, organazationId);
                return pmo;
            }
            catch (Exception)
            {
                throw new ArgumentNullException("We don't have such a PersonnelMainOffice");
            }
            
        }
        public int GetOrganazationId(string orgName = "", string orgCode = "")
        {
            var OrganazationId = _organazationDBset.Where(p => p.Name == orgName && p.Code == orgCode)
                .AsNoTracking().Select(p => p.Id).SingleOrDefault();
            if (OrganazationId == default)
            {
                Console.WriteLine("We don't have such a organaztion.");
            }
            return OrganazationId;
        }

        public int GetPersonnelId(string PersonnelName = "", string PersonnelFamily = "",
            string nationalCode = "")
        {
            var personnelId = _personnelDBset.Where(p => p.Name == PersonnelName &&
               p.Family == PersonnelFamily || p.NationalCode == nationalCode)
                .AsNoTracking().Select(p => p.Id).SingleOrDefault();
            if (personnelId == default)
            {
                Console.WriteLine("We don't have such a Personnel.");
            }
            return personnelId;

        }

        public void InsertPersonnelMainOffice(PersonnelMainOfficeDTO pmodto)
        {
            var perId = GetPersonnelId(pmodto.PersonnelNameDTO, pmodto.PersonnelFamilyDTO
               , pmodto.NationalCodeDTO);
            var orgId = GetOrganazationId(pmodto.OrgNameDTO, pmodto.OrgCodeDTO);

            if (orgId == default && perId == default)
            {
                Console.WriteLine("We don't have this Personel and this Organazation.");
            }
            var pmoId = new PersonnelMainOffice
            {
                PersonnelId = perId,
                OrganzationId = orgId
            };
            _pmo.Add(pmoId);
            if (pmoId != null)
                Console.WriteLine("Personnel Main Office Inserted sucessfully.");
        }

        //public PersonnelMainOfficeDTO FindPMO(PersonnelMainOfficeDTO pmodto)
        //{
        //    var perId = GetPersonnelId(pmodto.PersonnelNameDTO, pmodto.PersonnelFamilyDTO
        //       , pmodto.NationalCodeDTO);
        //    var orgId = GetOrganazationId(pmodto.OrgNameDTO, pmodto.OrgCodeDTO);

        //    var pmo = _pmo.Where(p => p.PersonnelId == perId && p.OrganzationId == orgId)
        //        .Select(p=>new {p.PersonnelId,p.OrganzationId}).SingleOrDefault();/////existance of this personnel main office ID
        //    if (pmo.PersonnelId == default && pmo.OrganzationId==default)
        //    {
        //        Console.WriteLine("We can't find this Personel Main Office.");
        //    }
        //    var dto = new PersonnelMainOfficeDTO
        //    {
        //        PersonnelNameDTO = pmodto.PersonnelNameDTO,
        //        PersonnelFamilyDTO = pmodto.PersonnelFamilyDTO,
        //        NationalCodeDTO = pmodto.NationalCodeDTO,
        //        OrgCodeDTO = pmodto.OrgCodeDTO,
        //        OrgNameDTO = pmodto.OrgNameDTO
        //    };
        //    return dto;
        //}

       public PersonnelMainOffice GetPersonnelById(int personnelId)
        {
            try
            {
                var personnel = _pmo.AsNoTracking().FirstOrDefault(x=>x.PersonnelId==personnelId);
                return personnel;
            }
            catch(Exception)
            {
                throw new ArgumentNullException 
              ("We don't have such a PersonnelId in PersonnelMainOffice ");
            }
        }
        public PersonnelMainOffice GetOrganazationById(int orgId)
        {
            try
            {
                var org = _pmo.FirstOrDefault(x=>x.OrganzationId==orgId);
                return org;
            }
            catch(Exception)
            {
                throw new ArgumentNullException
             ("We don't have such a OrganzationId in PersonnelMainOffice ");
            }
        }
    //    public bool UpdatePersonnelMainOffice(PersonnelMainOfficeDTO newData, PersonnelMainOfficeDTO oldData)
    //    {

    //        var perIdnew = GetPersonnelId(newData.PersonnelNameDTO, newData.PersonnelFamilyDTO
    //          , newData.NationalCodeDTO);
    //        var orgIdnew = GetOrganazationId(newData.OrgNameDTO, newData.OrgCodeDTO);

    //        if (orgIdnew == default && perIdnew == default)
    //        {
    //            Console.WriteLine("We can't update this Personel Main Office.");
    //            return false;
    //        }
    //        ///// I read this following code perIdold and orgIdold and pmoi beacuse I need to
    //        ///find the Id of composite key that I need to update so I should find that id to change 
    //        ///it and insert new value in it .
    //        var perIdold = GetPersonnelId(oldData.PersonnelNameDTO, oldData.PersonnelFamilyDTO
    //           , oldData.NationalCodeDTO);
    //        var orgIdold = GetOrganazationId(oldData.OrgNameDTO, oldData.OrgCodeDTO);

    //        var pmoi = _pmo.Where(p => p.PersonnelId == perIdold && p.OrganzationId == orgIdold)
    //.SingleOrDefault();
    //        var pmo = pmoi;
    //        pmo.PersonnelId = perIdnew;
    //        pmo.OrganzationId = orgIdnew;
    //        _pmo.Attach(pmo).State = EntityState.Modified;
    //        return true;
    //    }


    }
}
