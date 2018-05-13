using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBHPIM.Database.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        public String Address { get; set; }
        public string SchoolDistrict { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public virtual Children GetChildren { get; set; }
    }
}
