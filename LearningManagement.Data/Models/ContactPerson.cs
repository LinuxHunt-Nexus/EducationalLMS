using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagement.Data.Models
{
    public class ContactPerson
    {
        public int ContactPersonId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }

        // MAHADI
        // Additional properties
        public string? Department { get; set; }
        public string? Company { get; set; }
        public string? Address { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? TwitterHandle { get; set; }
        public DateTime BirthDate { get; set; }
        public string? FacebookProfile { get; set; }
        public string? InstagramProfile { get; set; }
        public bool CanCall { get; set; }
        public bool CanEmail { get; set; }
        public bool CanSMS { get; set; }
        public string? Availability { get; set; }
        public string? Relationship { get; set; }
        public bool IsEmergencyContact { get; set; }
        public string? EmergencyRelation { get; set; }
        public string? EmergencyPhone { get; set; }
    }
}
