using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;
using Office.DataLayer.DTO_Class;

namespace Office.DataLayer.Repository
{
    public  interface IPersonnelMainOfficeService
    {
       IList<PersonnelMainOffice> GetAllPMO();     
        void InsertPersonnelMainOffice(PersonnelMainOfficeDTO pmodto);

       // bool UpdatePersonnelMainOffice(int PersonnelId , PersonnelMainOfficeDTO oldData);
       //we can't update table with record that consist of just forien key
        bool DeletePersonnelMainOffice(int personnelId, int orgId);

        // PersonnelMainOfficeDTO GetPMOInfo(PersonnelMainOffice pmo );
        // we use this 
        //for console but it can use other place

        //  PersonnelMainOfficeDTO FindPMO(PersonnelMainOfficeDTO pmodto);

        PersonnelMainOfficeDTO GetPMOInfoById(int personnelId, int organazationId);

        PersonnelMainOffice GetPMOById(int personnelId,int organazationId);
        //we need to find pmo from pmo table not another tables

        PersonnelMainOffice GetPersonnelById(int personnelId);
        PersonnelMainOffice GetOrganazationById(int orgId);

        int GetPersonnelId(string PersonnelName = "", string PersonnelFamily = "",
           string nationalCode = "");
        int GetOrganazationId(string orgName = "", string orgCode = "");
    }
}
