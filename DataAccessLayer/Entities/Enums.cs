namespace DataAccessLayer.Entities;

public class Enums
{
    public enum PatientProgress
    {
        InHome,
        InMyWayToClinic,
        InClinic
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
    public enum  Gender
    {
        man ,
        female
    }
}