using System.ComponentModel.DataAnnotations;

namespace eRestoran.Api.VM
{
    public class AuthVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}