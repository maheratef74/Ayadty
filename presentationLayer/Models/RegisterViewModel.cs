namespace Ayadty.Models
{
 
    public class RegisterViewModel
    {
        // Common Fields
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Password { get; set;}

        // Doctor-Specific Fields
        public int? YearsOfExperience { get; set; }
        public decimal? Price { get; set; }

        // Patient-Specific Fields
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }
}