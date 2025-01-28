namespace TASK_CLI
{
    public class Task
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public StatusTask Status { get; set; }

        public DateOnly CreateAt { get; set; }
        public DateOnly UpdateAt { get; set; }

        public Task()
        {
            Id = 0;
            Description = "";
            Status = StatusTask.todo;
            CreateAt = DateOnly.Parse(DateTime.Now.ToString("dd-MM-yyyy"));
            UpdateAt = DateOnly.Parse(DateTime.Now.ToString("dd-MM-yyyy"));
        }

        public Task(
            int id,
            string description,
            StatusTask status,
            DateOnly createAt,
            DateOnly updateAt
        )
        { 
            Id = id;
            Description = description;
            Status = status;
            CreateAt = createAt;
            UpdateAt = updateAt;
        }

        public override string ToString()
        {
            var status = StatusTaskUtils.GetEnumMemberValue<StatusTask>(Status);

            return $"{Id} {Description} {status} {CreateAt:dd-MM-yyyy} {UpdateAt:dd-MM-yyyy}";
        }

    }
}
