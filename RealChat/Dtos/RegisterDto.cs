using System.ComponentModel.DataAnnotations;

namespace RealChat.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required, Compare(nameof(Password), ErrorMessage = "Password does not match. Try again.")]
        public string ConfirmPassword { get; set; }
    }
}