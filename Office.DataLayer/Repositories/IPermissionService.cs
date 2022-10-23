using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;
using Office.DataLayer.DTO_Class;

namespace Office.DataLayer.Repository
{
    public interface IPermissionService
    {
        IList<Permission> GetAllPermission();
        bool InsertPermission(PermissionDTO permissiondto);
       // bool UpdatePermission(PermissionDTO newdata, PermissionDTO oldData);
        //we can't update table with record that consist of just forien key
        bool DeletePermissionBy2ID(int personnelId, int orgId);

        // PermissionDTO Get(Permission permissiondto);
        // we use this 
        //for console but it can use other place

        PermissionDTO GetPermissionInfoById(int personnelId, int organazationId);

        Permission GetPermissionById(int personnelId, int organazationId);

        IList<Permission> GetPersonnelById(int personnelId);
        IList<Permission> GetOrganazationById(int orgId);

        //  PermissionDTO FindPMO(PermissionDTO permissiondto);
        int GetPersonnel(string PersonnelName = "", string PersonnelFamily = "",
           string nationalCode = "");
        int GetOrganazation(string orgName = "", string orgCode = "");
    }
}
