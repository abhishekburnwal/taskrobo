using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    public class AppUser
    {
        [Key]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
