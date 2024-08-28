namespace Ayadty.Models;

public class Enums
{
    public enum UserType
    {
        Doctor,
        Patient
    }
    public enum Specialization
    {
        GeneralPractitioner,
        Cardiologist,
        Dermatologist,
        Neurologist,
        Pediatrician,
        Orthopedic,
        Gynecologist,
        // Add more specializations as needed
    }
    public enum AppointmentStatus
    {
        Scheduled,
        Canceled ,
        Completed
    }
    public enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}