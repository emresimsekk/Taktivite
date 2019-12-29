using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taktivite.Entity
{
    [Table("Participant")]
    public class Participant:EntityBase
    {
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
         , Display(Name = "Katılımcı Sayısı")
         , StringLength(2, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string ParticipantName { get; set; }


        public virtual List<Activity> Activitys { get; set; }

        public Participant()
        {
            Activitys = new List<Activity>();
        }
    }
}
