using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBHPIM.Database.Models
{
    public class Parent
    {
        [Key]
        public int ParentID { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateRegisterd { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
    }
}
