using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taktivite.Entity
{
    [Table("State")]
    public class State:EntityBase
    {
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Durum")
        , StringLength(20, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string StateName { get; set; }

        public virtual List<Activity> Activitys { get; set; }
        public State()
        {

            Activitys = new List<Activity>();
        }


    }
}
