using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class UserSıgnInViewModel
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz1")]
        public string usernama { get; set; }
        [Required(ErrorMessage ="Lütfen şifrfenizi giriniz1")]
        public string password { get; set; }
    }
}
