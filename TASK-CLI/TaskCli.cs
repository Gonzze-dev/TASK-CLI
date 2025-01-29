using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_CLI
{
    public static class TaskCli
    {
        public static void TaskCliApp(string[] args)
        {
            var commandLength = args.Length;
            var resultAction = "";

            if (commandLength == 0 || args[0] != "task-cli")
            {
                Console.WriteLine("task-cli [command]");
                Console.WriteLine("Commands:");
                Console.WriteLine("  add <description>                     Add task to list.");
                Console.WriteLine("  update <id> <description>             Update a task of the list.");
                Console.WriteLine("  delete <id>                           Delete a task of the list.");
                Console.WriteLine("  mark-in-progress <id>                 Marking a task as in progress");
                Console.WriteLine("  mark-done <id>                        Marking a task as done");
                Console.WriteLine("  list                                  Listing all tasks");
                Console.WriteLine("  list <status>                         Listing tasks by status");
                return;
            }

            var command = args[1];

            if (command == "add" && commandLength == 3)
                Commander.Add(args, out resultAction);

            else if (command == "update" && commandLength == 4)
                Commander.Update(args, out resultAction);

            else if (command == "delete" && commandLength == 3)
                Commander.Delete(args, out resultAction);

            else if (command.StartsWith("mark") && commandLength == 3)
                Commander.Mark(args, out resultAction);

            else if (command == "list" && commandLength == 2)
                Commander.List(out resultAction);

            else if (command == "list" && commandLength == 3)
                Commander.ListBy(args, out resultAction);

            Console.WriteLine(resultAction);
        }
    }
}
