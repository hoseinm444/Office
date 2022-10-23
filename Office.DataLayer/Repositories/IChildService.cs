using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataLayer.Models;

namespace Office.DataLayer.Repository
{
    public interface IChildService
    {
        IList<ChildOfPerosnnel> GetAllChild();
        ChildOfPerosnnel GetChildById(int Id);
        void InsertChild(ChildOfPerosnnel Child);
        bool UpdateChild(ChildOfPerosnnel Child);

        //  bool DeleteChild(ChildOfPerosnnel child); this argument just for console
        bool DeleteChildById(int Id);
        int PersonnelIdByName(string Personelname);
        ChildOfPerosnnel GetChildUpdate(string name = "", string family = "",
            string fathernam="", string Nationalcode = "");
    }
}
