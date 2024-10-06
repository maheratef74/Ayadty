using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Clinic;
using DataAccessLayer.Entities;

    public class ClinicDetailsDto
    {
        public int clinicId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ProfilePhoto { get; set; }

   
}

