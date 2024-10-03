using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Models.DashBoard.ViewModel;

public class NurseAppointmentVM
{
    
    public int SelectedPatientId { get; set; }
    public string patientPhone { get; set; }
    public List<PatientVM> Patients { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public string SearchTerm { get; set; } 
}