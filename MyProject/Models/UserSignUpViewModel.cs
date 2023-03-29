using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Lütfen ad soyadınızı giriniz!")]
        public string nameSurname { get; set; }
        [Display(Name = "Şifre")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreleriniz aynı olsun!")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail Adresi")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen mail giriniz!")]
        public string Mail { get; set; }
        [Display(Name = "Kyllanıcı")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz!")]
        public string UserName { get; set; }
    }
}
