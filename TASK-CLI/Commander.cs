using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_CLI
{
    public static class Commander
    {
        public static void Add(string[] args, out string resultAction) 
        {
            string description = args[2];
            resultAction = TaskService.Add(description);
        }

        public static void Update(string[] args, out string resultAction)
        {
            bool result = int.TryParse(args[2], out int id);

            if (!result)
            {
                resultAction = "Error, argumento invalido";
                return;
            }

            string description = args[3];
            resultAction = TaskService.UpdateDescription(id, description);
        }

        public static void Delete(string[] args, out string resultAction)
        {
            bool result = int.TryParse(args[2], out int id);

            if (!result)
            {
                resultAction = "Error, invalid argument";
                return;
            }

            resultAction = TaskService.Delete(id);
        }

        public static void Mark(string[] args, out string resultAction)
        {
            var statusString = args[1][5..];

            StatusTask? status = StatusTaskUtils.GetEnumByStringValue(statusString);

            if (status == null)
            {
                resultAction = "Error, invalid status";
                return;
            }

            bool result = int.TryParse(args[2], out int id);

            if (result == null)
            {
                resultAction = "Error, invalid argument";
                return;
            }

            resultAction = TaskService.UpdateStatus(id, status.Value);
        }

        public static void List(out string resultAction)
        {
            var result = TaskService.List();
            resultAction = "";

            if (!result.Any())
            { 
                resultAction = "List are empty";
                return;
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public static void ListBy(string[] args, out string resultAction)
        {
            resultAction = "";
            IEnumerable<Task> result;
            StatusTask? status = StatusTaskUtils.GetEnumByStringValue(args[2]);
            

            if (status == null)
            {
                resultAction = "Error, invalid status";
                return;
            }

            result = TaskService.ListBy(status.Value);

            if (!result.Any())
            {
                resultAction = "List are empty";
                return;
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
