using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taktivite.Entity.ValueObject
{
    public class EventListViewModel
    {
        [DisplayName("Kategori ID")]
        public int CategoryID { get; set; }

       
        [DisplayName("Range ID")]
        
        public int RangeID { get; set; }
        [DisplayName("Enlem")]
        public string Latitude { get; set; }

        [DisplayName("Boylam")]
        public string Longitude { get; set; }
    }
}
