using System.ComponentModel.DataAnnotations;

namespace MyTimeProject.API.Models
{
    public class LoginModel
    {

        [Required]
        public string UserName { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
