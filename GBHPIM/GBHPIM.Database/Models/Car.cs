using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBHPIM.Database.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public int License { get; set; }
        public byte[] PictureOFCar { get; set; }
        public DateTime Year { get; set; }
        public string MakeModel { get; set; }
        public int PlateNumber { get; set; }
        public virtual Parent ParentCar { get; set; }
    }
}
