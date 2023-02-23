using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.DTO
{
    public class TaskManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskManagementID { get; set; }

        [Required]
        [DisplayName("Task Name")]
        public string TaskName { get; set; }

        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime TTime { get; set; }

        public string Status { get; set; }
    }
}
