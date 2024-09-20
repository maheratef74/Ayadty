using System.ComponentModel.DataAnnotations;

namespace presentationLayer.Models.Auth.ActionRequest;

public class LoginAR
{
    [Required(ErrorMessage = "PhoneNumberRequired")]
    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "PasswordIsRequired")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool  RememberMe { get; set; }
}