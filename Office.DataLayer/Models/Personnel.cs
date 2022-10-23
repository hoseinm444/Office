using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.DataLayer.Models
{
    public class Personnel
    {
        public int Id { get; set; }
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Family { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string NationalCode { get; set; }
        public virtual PersonnelMainOffice PerosnnelMainOffice { get; set; }
        public Gender PersonnelGender { get; set; }

        public virtual IList<Permission> Permissions { get; set; }
    }
    public enum Gender : int
    {
        Men = 1,
        Wemon = 2
    }
}
