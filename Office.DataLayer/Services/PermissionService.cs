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
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Personnel> _personnelDBset;
        private readonly DbSet<Organazation> _organazationDBset;
        private readonly DbSet<Permission> _permission;
        public PermissionService(IUnitOfWork uow)
        {
            _uow = uow;
            _personnelDBset = _uow.Set<Personnel>();
            _organazationDBset = _uow.Set<Organazation>();
            _permission = _uow.Set<Permission>();
        }

        //public bool DeletePermission(PermissionDTO permissiondto)
        //{
        //    var perId = GetPersonnel(permissiondto.PersonnelNameDTO, permissiondto.PersonnelFamilyDTO
        //        , permissiondto.NationalCodeDTO);
        //    var orgId = GetOrganazation(permissiondto.OrgNameDTO, permissiondto.OrgCodeDTO);
        //    var permissId = _permission.Where(p => p.PersonnelId == perId && p.OrganzationId == orgId)
        //        .SingleOrDefault();
        //    if (orgId == default || perId == default)
        //    {
        //        Console.WriteLine("We Can't delete this Permission .");
        //        return false;
        //    }

        //    _permission.Attach(permissId).State = EntityState.Deleted;
        //    return true;
        //}

        public Permission GetPermissionById(int personnelId, int organazationId)
        {
            try
            {
                var x = _personnelDBset.Where(p => p.Id == personnelId)
                .AsNoTracking().Select(p => p.Id).SingleOrDefault();
                var org = _organazationDBset.Where(p => p.Id == organazationId)
                  .AsNoTracking()
                  .Select(p => p.Id).SingleOrDefault();


                if (x == default || org == default)
                {
                    throw new ArgumentNullException("we don't have such PersonnelId or organazattionId");
                }

                var permission = _permission.Where(p => p.PersonnelId == x && p.OrganzationId == org).
                    AsNoTracking().FirstOrDefault();

                return permission;
            }
            catch(Exception)
            {
                 throw new ArgumentNullException("we don't have such Permission");
            }

        }

       // /2 people can be in 2 office
        public IList<Permission> GetPersonnelById(int personnelId)
        {
            try
            {
                var permission = _permission.Where(p => p.PersonnelId == personnelId)
                    .AsNoTracking().ToList();
                if (permission == null)
                {
                    throw new ArgumentNullException("we don't have such PersonnelId");
                }
                return permission;
            }
           catch(Exception)
            {
                throw new ArgumentNullException("we don't have such Permission");
            }


        }

        //2 people can be in 2 office 

       public IList<Permission> GetOrganazationById(int orgId)
        {
            try
            {
                var permission = _permission.Where(p=>p.OrganzationId==orgId)
                    .AsNoTracking().ToList();
                if (permission == null)
                {
                    throw new ArgumentNullException("we don't have such OrganazationId ");
                }
                return permission;
            }
            catch(Exception)
            {
                throw new ArgumentNullException("we don't have such Permission");
            }
        }
        public IList<Permission> GetAllPermission()
        {
            return _permission.AsNoTracking().ToList();
        }

       public PermissionDTO GetPermissionInfoById(int personnelId, int organazationId)
        {
            try
            {
                var org = _organazationDBset.SingleOrDefault(x=>x.Id==organazationId);
                var personnel = _personnelDBset.Find(personnelId);

                if(org==null || personnel==null)
                {
                    throw new ArgumentNullException
                        ("your organazationId and PersonnelId isn't correct");
                }
                else
                {
                    var permissiondto = new PermissionDTO()
                    {
                        PersonnelNameDTO = personnel.Name,
                        PersonnelFamilyDTO = personnel.Family,
                        NationalCodeDTO = personnel.NationalCode,
                        OrgNameDTO = org.Name,
                        OrgCodeDTO = org.Code
                    };

                    return permissiondto;
                }
               
            }
            catch (Exception)
            {
                throw new ArgumentNullException("We don't have such a Permission in permission table ");
            }
        }

        public int GetOrganazation(string orgName = "", string orgCode = "")
        {
            var OrganazationId = _organazationDBset.Where(p => p.Name == orgName && p.Code == orgCode)
                .AsNoTracking().Select(p => p.Id).SingleOrDefault();
            if (OrganazationId == default)
            {
                Console.WriteLine("We don't have such a organaztion.");
            }
            return OrganazationId;
        }

        public int GetPersonnel(string PersonnelName = "", string PersonnelFamily = "",
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

        public bool InsertPermission(PermissionDTO permissiondto)
        {
            var perId = GetPersonnel(permissiondto.PersonnelNameDTO, permissiondto.PersonnelFamilyDTO
               , permissiondto.NationalCodeDTO);
            var orgId = GetOrganazation(permissiondto.OrgNameDTO, permissiondto.OrgCodeDTO);

            if (orgId == default || perId == default)
            {
                throw new ArgumentNullException("We don't have this Personel and this Organazation.");
            }
            var permis = _permission.Where(p => p.OrganzationId == orgId && p.PersonnelId
              == perId).FirstOrDefault();
           
            var permissionId = new Permission
            {
                PersonnelId = perId,
                OrganzationId = orgId
            };
            if (permis == permissionId)
                throw new ArgumentException("you can't insert iterrative value");
                _permission.Add(permissionId);
            return true;
        }

        //public PermissionDTO FindPMO(PermissionDTO permission)
        //{
        //    var perId = GetPersonnel(permission.PersonnelNameDTO, permission.PersonnelFamilyDTO
        //       , permission.NationalCodeDTO);
        //    var orgId = GetOrganazation(permission.OrgNameDTO, permission.OrgCodeDTO);
        //    var pmo = _permission.Where(p => p.PersonnelId == perId && p.OrganzationId == orgId)
        //        .SingleOrDefault();
        //    if (pmo == default)
        //    {
        //        Console.WriteLine("We can't find this Personel Main Office.");
        //    }
        //    var dto = new PermissionDTO
        //    {
        //        PersonnelNameDTO = _personnelDBset.Where(p => p.Id == perId).Select(p => p.Name).SingleOrDefault(),
        //        PersonnelFamilyDTO = _personnelDBset.Where(p => p.Id == perId).Select(p => p.Family).SingleOrDefault(),
        //        NationalCodeDTO = _personnelDBset.Where(p => p.Id == perId).Select(p => p.NationalCode).SingleOrDefault(),
        //        OrgCodeDTO = _organazationDBset.Where(p => p.Id == orgId).Select(p => p.Code).SingleOrDefault(),
        //        OrgNameDTO = _organazationDBset.Where(p => p.Id == orgId).Select(p => p.Name).SingleOrDefault()
        //    };
        //    return dto;
        //}

        //public bool UpdatePermission(PermissionDTO newData, PermissionDTO oldData)
        //{

        //    var perIdnew = GetPersonnel(newData.PersonnelNameDTO, newData.PersonnelFamilyDTO
        //       , newData.NationalCodeDTO);
        //    var orgIdnew = GetOrganazation(newData.OrgNameDTO, newData.OrgCodeDTO);

        //    if (orgIdnew == default && perIdnew == default)
        //    {
        //        Console.WriteLine("We can't update this Permission .");
        //        return false;
        //    }
        //    ///// I read this following code perIdold and orgIdold and pmoi beacuse I need to
        //    ///find the Id of composite key that I need to update so I should find that id to change 
        //    ///it and insert new value in it .
        //    var perIdold = GetPersonnel(oldData.PersonnelNameDTO, oldData.PersonnelFamilyDTO
        //       , oldData.NationalCodeDTO);
        //    var orgIdold = GetOrganazation(oldData.OrgNameDTO, oldData.OrgCodeDTO);
        //    var pmoi = _permission.Where(p => p.PersonnelId == perIdold && p.OrganzationId == orgIdold)
        //     .SingleOrDefault();
        //    var pmo = pmoi;
        //    pmo.PersonnelId = perIdnew;
        //    pmo.OrganzationId = orgIdnew;
        //    _permission.Attach(pmo).State = EntityState.Modified;
        //    return true;
        //}


        //we can't have delete prmission with 1 id becuase we have some composite key
        // that have same orgid or personnelid and it can make confusing or confusion
       //public bool DeletePermissionById(int Id)
       // {
       //     //var permissionId = _permission.Where(p => p.PersonnelId == Id ||
       //     // p.OrganzationId == Id);
       //     //if (permissionId == default)
       //     //{
       //     //    throw new ArgumentException("We Can't delete this Permission .");
       //     //}

       //     //_permission.Attach(permissionId).State = EntityState.Deleted;
       //     //return true;
       // }
        public bool DeletePermissionBy2ID(int personnelId, int orgId)
        {
            var perId = _personnelDBset.SingleOrDefault(x=>x.Id == personnelId);
            var orgaId = _organazationDBset.SingleOrDefault(x => x.Id ==orgId);
            if (orgaId == default || perId == default)
            {
                throw new ArgumentException("We don't have this Permission .");
            }

            var permissId = _permission.Where(p => p.PersonnelId == perId.Id &&
            p.OrganzationId == orgaId.Id).SingleOrDefault();
          

            _permission.Attach(permissId).State = EntityState.Deleted;
            return true;
        }
    }
}
