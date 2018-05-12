using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBHPIM.Database.Models
{
    class Parent
    {
        [Key]
        public int ParentID { get; set; }
        public int Children { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateRegistred { get; set; }
        public int MyProperty { get; set; }
    }
}
