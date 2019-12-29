using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taktivite.Entity
{   
    [Table("User")]
    public class User:EntityBase
    {
        [Display(Name ="Kullanıcı Adı"),
         Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string UserName { get; set; }


        [Display(Name ="Şifre"),
        Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Kullanıcı Adı")
        , StringLength(30, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Kullanıcı Soyadı")
        , StringLength(30, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Kullanıcı Resmi")
        , StringLength(30, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string UserImagesName { get; set; }

      

        public virtual List<Activity> Activities{ get; set; }

        public User()
        {
            Activities = new List<Activity>();
        }

    }
}
