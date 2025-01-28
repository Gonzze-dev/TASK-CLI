using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace TASK_CLI
{
    public class TaskRepository
    {
        private readonly string _path = "tasks.json";
        public List<Task> Tasks { get; set; }
        public TaskRepository() {
            Tasks = LoadData();
        }
        
        public Task? GetById(int id) => 
            Tasks.Find(task => task.Id == id);

        public IEnumerable<Task> ListBy(StatusTask status) =>
         Tasks.Where(task => task.Status == status);

        public void Add(Task newTask)
        {
            Tasks.Add(newTask);
            Save();
        }

        public void Update(Task uTask)
        {
            
            Tasks.Where(task => task.Id == uTask.Id)
            .ToList()
            .ForEach(task =>
            {
                task.Description = uTask.Description;
                task.Status = uTask.Status;
            });

            Save();
        }

        public void Delete(int id)
        {
            Tasks.RemoveAll(task => task.Id == id);
            Save();
        }
        
        void Save()
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new EnumMemberConverter<StatusTask>() },
                WriteIndented = true,
                
            };

            var json = JsonSerializer.Serialize(Tasks, options);
            File.WriteAllText(_path, json);
        }

        List<Task> LoadData()
        {
            string path = _path;
            string jsonString = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                Converters = { new EnumMemberConverter<StatusTask>() }
            };

            var tasks = JsonSerializer.Deserialize<List<Task>>(jsonString, options) ?? [];

            return tasks;
        }
    }
}
