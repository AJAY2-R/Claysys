using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class JobSeekerModel
    {
        [Key]
        public int SeekerId { get; set; }
        [Required(ErrorMessage = "Enter the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter the last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter the email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select the date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Invalid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public byte[] Resume { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Experience must be non-negative")]
        public double Experience { get; set; }

        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Select a city")]
        public String City { get;set; }
        [Required(ErrorMessage = "Enter the address")]
        public string Address { get;set; }
        [Required(ErrorMessage = "Select a state")]
        public string State { get;set; }
        [Required(ErrorMessage = "Enter the username")]
        public string Username { get;set; }
    }
}