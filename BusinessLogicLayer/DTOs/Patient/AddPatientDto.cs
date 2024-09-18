using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Patient
{
    public class AddPatientDto
    {
        public string PhoneNumber { get; set; } 
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        public Enums.Gender Gender { get; set; }
        
    }
}
