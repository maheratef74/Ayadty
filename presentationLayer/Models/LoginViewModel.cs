using System.ComponentModel.DataAnnotations;

namespace Ayadty.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please enter your password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
}