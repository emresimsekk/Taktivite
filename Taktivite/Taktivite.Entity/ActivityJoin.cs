using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Taktivite.Entity
{
    [Table("ActivityJoin")]

    public class ActivityJoin :EntityBase
    {
       
        
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Aktivite ID")]
        public int ActivityID { get; set; }

       

        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Kullanıcı Adı")]
        public int UserID { get; set; }


        public virtual List<Activity> Activitys { get; set; }

    }

   
}
