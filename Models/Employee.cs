using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpCrud.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "Last name")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [Display(Name = "Phone Number")]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int Zip { get; set; }
        public int Age { get; set; }

        public byte[] Photo { get; set; }
        [NotMapped]
        [Display(Name = "ImageFile")]
        public IFormFile ImageFile { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        public Department department { get; set; }
    }
}
