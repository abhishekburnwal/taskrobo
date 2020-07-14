using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    // Create LoginViewModel and add required properties with appropriate validations

    // Email - string (required), validate email address pattern
    // Password - string (required), should display password characters instead of normal text in the field
    // RememberMe - bool, should be displayed as "Remember Me?" on the view
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    // Create RegisterViewModel and add required properties with appropriate validations

    // Email - string (required), validate email address pattern
    // Password - string (required), should display password characters instead of normal text in the field. Minimum length of the password should be 6 and maximum 100
    // ConfirmPassword - string (required), should display password characters instead of normal text in the field. Minimum length of the password should be 6 and maximum 100. Should match with password field
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
