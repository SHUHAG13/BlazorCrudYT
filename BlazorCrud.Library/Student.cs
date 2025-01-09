using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Library
{
	public class Student
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Father Name is required")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [Range(1,9)]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Roll num is required")]
        public int RollNumber { get; set; }
    }
}
