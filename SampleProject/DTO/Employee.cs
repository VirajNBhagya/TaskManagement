
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.DTO
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="Please Enter Employee Name")]
        [Column(TypeName ="nvarchar(25)")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage ="Please Enter Address")]
        [Column(TypeName ="nvarchar(100)")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage ="Please Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter DOB")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}
