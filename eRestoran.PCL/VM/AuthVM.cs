using System.ComponentModel.DataAnnotations;

namespace eRestoran.PCL.VM
{
    public class AuthVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}