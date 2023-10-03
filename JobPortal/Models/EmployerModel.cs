using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;

namespace JobPortal.Models
{
    public class EmployerModel
    {
        [Key]
        public int EmployerID { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Official Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string OfficialEmail { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }
        [Required(ErrorMessage ="Enter the phone number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage ="Enter the url ")]
        [Url(ErrorMessage = "Invalid Website URL")]
        public string Website { get; set; }
        [Display(Name ="Full name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters")]
        public string Designation { get; set; }

        public byte[] CompanyLogo { get; set; }
    }
}