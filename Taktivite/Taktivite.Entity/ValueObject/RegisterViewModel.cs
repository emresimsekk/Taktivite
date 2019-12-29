using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Taktivite.Entity.ValueObject
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"),
        Required(ErrorMessage = "{0} alanı boş geçilemez."),
        MinLength(8, ErrorMessage = "{0} min {1} karakter olmalı."),
        MaxLength(12, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string UserName { get; set; }

        [DisplayName("Şifre"),
        Required(ErrorMessage = "{0} alanı boş geçilemez."),
        MinLength(8, ErrorMessage = "{0} min {1} karakter olmalı."),
        MaxLength(12, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."),
        DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [DisplayName("Ad"),
        Required(ErrorMessage = "{0} alanı boş geçilemez."),
        MinLength(3, ErrorMessage = "{0} min {1} karakter olmalı."),
        MaxLength(20, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"),
        Required(ErrorMessage = "{0} alanı boş geçilemez."),
        MinLength(3, ErrorMessage = "{0} min {1} karakter olmalı."),
        MaxLength(20, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }
    }
}
