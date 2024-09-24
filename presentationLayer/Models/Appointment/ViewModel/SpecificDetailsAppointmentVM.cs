using System;
using System.Collections.Generic;
using BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Entities;


namespace PresentationLayer.Models.Appointment.ViewModel
{
    public class SpecificDetailsAppointmentVM
    {
        public List<SpecificAppointmentDetailsVM> Appointments { get; set; }
    }

    public class SpecificAppointmentDetailsVM
    {
        public string AppointmentId { get; set; }
        public string PatientId { get; set; }
        public DateTime Date { get; set; }
        public int Order { get; set; }
        public Enums.AppointmentStatus AppointmentStatus { get; set; }
    }

    public static class AppoinrmentExtensionMethold
    {
        public static List<SpecificAppointmentDetailsVM> ToAppointmentspecificDetailsVms(this List<AppointmentDetailsDto> appointmentsDetailsDto)
        {
            var appointmentsDetails = appointmentsDetailsDto.Select(a => new SpecificAppointmentDetailsVM
            {
                AppointmentId = a.AppointmentId, 
                PatientId = a.PatientId, 
                Date = a.Date,
                Order = a.Order,
                AppointmentStatus = a.Status
            }).ToList();
            return appointmentsDetails;
        }
    }

}