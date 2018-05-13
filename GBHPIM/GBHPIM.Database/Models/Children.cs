using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBHPIM.Database.Models
{
    public class Children
    {
        [Key]
        public int ChildrenID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public virtual Parent GetParent { get; set; }
    }
}
