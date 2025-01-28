using System.Globalization;

namespace TASK_CLI
{
    public static class TaskService
    {
        static TaskRepository Repository { get; set; } = new();

        public static string Add(string description)    
        {
            var id = Repository.Tasks.Last().Id + 1;

            var date = DateOnly.Parse(DateTime.Now.ToString("dd-MM-yyyy"));

            Task task = new()
            {
                Id = id,
                Description = description,
                Status = StatusTask.todo,
                CreateAt = date,
                UpdateAt = date
            };

            Repository.Add(task);

            return $"Task added successfully (ID: {id})";
        }

        public static string UpdateDescription(int id, string description)
        {
            var task = Repository.GetById(id);

            if (task == null)
                return $"Task (ID: {id}) doesnt exist";

            task.Description = description;

            Repository.Update(task);

            return $"Task update description successfully (ID: {id})";
        }

        public static string UpdateStatus(int id, StatusTask status)
        {
            var task = Repository.GetById(id);

            if (task == null)
                return $"Task (ID: {id}) doesnt exist";

            task.Status = status;

            Repository.Update(task);

            return $"Task update status (ID: {id})";
        }

        public static string Delete(int id)
        {
            var task = Repository.GetById(id);

            if (task == null)
                return $"Task doesnt exist";

            Repository.Delete(id);
            
            return $"Task delete successfully (ID: {id})";
        }

        public static IEnumerable<Task> List() =>
            Repository.Tasks;

        public static IEnumerable<Task> ListBy(StatusTask status) =>
         Repository.ListBy(status);

    }
}
