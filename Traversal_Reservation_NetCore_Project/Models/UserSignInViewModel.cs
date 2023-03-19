using System.ComponentModel.DataAnnotations;

namespace Traversal_Reservation_NetCore_Project.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı adınızı giriniz")]
        public string password { get; set; }
    }
}
