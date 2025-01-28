using System;
using System.Collections.Generic;
using System.IO;
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
            if (!File.Exists(_path))
            {
                string initialContent = "[]";
                File.WriteAllText(_path, initialContent);
            }

            Tasks = LoadData();
        }
        
        public Task? GetById(int id) => 
            Tasks.Find(task => task.Id == id);

        public int GetLastId()
        {
            var task = Tasks.LastOrDefault();
            var id = task == null ? 1 : task.Id + 1;

            return id;
        }
           

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
            List<Task> tasks = [];

            try
            {
                string jsonString = File.ReadAllText(path);

                var options = new JsonSerializerOptions
                {
                    Converters = { new EnumMemberConverter<StatusTask>() },
                    AllowTrailingCommas = true
                };

                tasks = JsonSerializer.Deserialize<List<Task>>(jsonString, options) ?? [];
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Could not find file");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tasks;
        }
    }
}
