namespace Ayadty.Models
{
 
    public class RegisterViewModel
    {
        // Common Fields
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Enums.UserType UserType { get; set; } // Enum for User Type

        // Doctor-Specific Fields
        public Enums.Specialization? Specialization { get; set; }
        public int? YearsOfExperience { get; set; }
        public decimal? Price { get; set; }

        // Patient-Specific Fields
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }
}