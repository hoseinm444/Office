using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.DataLayer.Models
{
   public class PersonnelMainOffice
    {
        public int PersonnelId { get; set; }
        public virtual Personnel Personnel { get; set; }
        public virtual Organazation Organiation { get; set; }
        public int OrganzationId { get; set; }
    }
}
