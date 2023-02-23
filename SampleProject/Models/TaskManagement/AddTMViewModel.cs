namespace SampleProject.Models.TaskManagement
{
    public class AddTMViewModel
    {
        public string TaskName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime TDate { get; set; }
        public DateTime TTime { get; set; }
        public string Status { get; set; }
    }

    public class UpdateTMViewModel
    {
        public int TaskManagementID { get; set; }
        public string TaskName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime TDate { get; set; }
        public DateTime TTime { get; set; }
        public string Status { get; set; }
    }

    public class CompleteTMViewModel
    {
        public int TaskManagementID { get; set; }
        public string TaskName { get; set; }
        public string EmployeeName { get; set; }
    }
}
