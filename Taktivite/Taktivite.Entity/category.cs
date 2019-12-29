using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taktivite.Entity
{
    [Table("Category")]
    public class Category:EntityBase
    {
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")
        , Display(Name = "Kategori")
        , StringLength(20, ErrorMessage = "{0} Alanı {1} Karakterden Uzun Olamaz")]
        public string CategoryName { get; set; }


        public virtual List<Activity> Activitys { get; set; }

        public Category()
        {
            Activitys = new List<Activity>();
        }


    }
}
