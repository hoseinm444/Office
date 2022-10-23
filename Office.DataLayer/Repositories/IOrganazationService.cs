using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;

namespace Office.DataLayer.Repository
{
    public interface IOrganazationService
    {
        IList<Organazation> GetAllOrganazation();
        Organazation GetOrganazationById(int Id);
        void InsertOrganazation(Organazation orgnazation);

        //bool UpdateOrganazation(int id);
        // bool UpdateOrganazation(Organazation oldData, Organazation newData);
        // this argument just for console because in console 
        //I should enter organazation attributes to find befor update.
        bool UpdateOrganazation(int Id, Organazation org);

        bool DeleteOrganazationById(int id); 
       // bool DeleteOrganazation(Organazation orgnazation);
       // this argument just for console because in console 
       //I should enter organazation attributes to find and delete.
        int ParrentOrganazationId(string orgName, string orgCode);
        string ParrentOrganazationName(int parrentId);
        string ParrentOrganazationCode(int parrentId);

    }
}
