using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;


namespace Office.DataLayer.Repository
{
    public interface IPersonnelService
    {
        IList<Personnel> GetAllPersonnel();
        Personnel GetPersonnelById(int Id);
        Personnel InsertPersonnel(Personnel personnel);
        bool UpdatePersonnel(Personnel personnel);
        //  bool DeletePersonnel(Personnel personnel); this argument just for console
        bool DeletePersonelById(int id);
        //  Personnel GetPersonnelForUpdate(Personnel personnel); just for console endpoint
       // Personnel GetPersonnelForUpdate(int Id);
        string AmountOfChild(string PersonnelName, string personnelFamily);
    }
}
