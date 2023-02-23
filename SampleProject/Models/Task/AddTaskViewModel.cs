namespace SampleProject.Models.Task
{
    public class AddTaskViewModel
    {
        public string TaskName { get; set; }
        public string TaskType { get; set; }
    }

    public class DetailsTaskViewModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
    }

    public class UpdateTaskViewModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
    }
}
