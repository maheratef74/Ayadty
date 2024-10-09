using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class Doctor : ApplicationUser
{
    public bool IsDoctor { get; set; }
    public int? YearsOfExperience { get; set; }
    public decimal? Price { get; set; }
}
