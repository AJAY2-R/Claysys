using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SingleStored.Models
{

    /// <summary>
    /// Student model
    /// </summary>
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Display(Name ="First name")]
        [Required (ErrorMessage ="Enter the first name")]
        public string FirstName { get; set; }

        [Display (Name ="Last name")]
        [Required(ErrorMessage ="Enter the last name ")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth ")]
        [Required(ErrorMessage = "Select the date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateOfBirth { get; set; }

        [Display (Name = "Address")]
        [Required(ErrorMessage ="Enter the address")]
        public string Address { get; set; }

        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Enter the email ")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        public byte[] Image { get; set; }
    }
}