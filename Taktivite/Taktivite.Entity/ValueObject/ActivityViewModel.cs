using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taktivite.Entity.ValueObject
{
    public class ActivityViewModel
    {
        [DisplayName("Activity ID")]
        public int Id { get; set; }

        [DisplayName("Kategori ID")]
        public int CategoryID { get; set; }


        [DisplayName("User ID")]
        public int UserID { get; set; }

        [DisplayName("Durum ID")]
        public int StateID { get; set; }

        [DisplayName("Katılımcı ID")]
        public int ParticipantID { get; set; }


        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Enlem")]
        public string Latitude { get; set; }

        [DisplayName("Boylam")]
        public string Longitude { get; set; }

        [DisplayName("İçerik")]
        public string Contents { get; set; }


    }
}
