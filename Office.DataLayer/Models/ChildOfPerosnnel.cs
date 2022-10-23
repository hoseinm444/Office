using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Office.DataLayer.Models
{
    public class ChildOfPerosnnel
    {
        public int Id { get; set; }
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [StringLength(150)]
        [Required]
        public string Family { get; set; }
        [Required]
        [StringLength(150)]
        public string FatherName { get; set; }
        [JsonIgnore]
        public int  PersonnelId { get; set; }
        /// <summary>
        /// //or public int? PersonnelId{get;set;}
        /// </summary>
        public virtual Personnel Personnel { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string NationalCode { get; set; }
        public Gender ChildGender { get; set; }
    }
}
