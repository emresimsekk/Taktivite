using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taktivite.Entity
{
    [Table("Activity")]
    public class Activity : EntityBase
    {

        [Display(Name = "Kategori Adı")]
       
        public int CategoryID { get; set; }


    
        [Display(Name = "Kullanıcı Adı")]
        
        public int UserID { get; set; }


       
        [Display(Name = "Durum")]
       
        public int StateID { get; set; }


   
        [Display(Name = "Katılımcı Sayısı")]
      
        public int ParticipantID { get; set; }



        [Display(Name = "Başlık")
        ,StringLength(50,ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string Title { get; set; }




        [ Display(Name = "Enlem")
        , StringLength(50, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string Latitude { get; set; }




        [Display(Name = "Boylam")
        , StringLength(50, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string Longitude { get; set; }



        [Display(Name = "İçerik")
        , StringLength(3000, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string Contents { get; set; }



        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual State State { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual List<ActivityJoin> ActivityJoins { get; set; }
        public Activity()
        {
            ActivityJoins = new List<ActivityJoin>();
        }






    }
}
