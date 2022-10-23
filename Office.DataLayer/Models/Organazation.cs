using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.DataLayer.Models
{
   public class Organazation
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Code { get; set; }
        public int ParrentOfficeId { get; set; }
        public int PersonnelMainOfficeId { get; set; }
        public virtual PersonnelMainOffice PerosnnelMainOffice { get; set; }
        public virtual IList<Permission> Permissions { get; set; }
    }
}
