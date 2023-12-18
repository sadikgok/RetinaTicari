using System.ComponentModel.DataAnnotations;

namespace RetinaTicari.WebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
