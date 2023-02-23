using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.DTO
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [Required]
        [DisplayName("Task Name")]
        public string TaskName { get; set; }

        [Required]
        [DisplayName("Task Type")]
        public string TaskType { get; set; }



    }
}
