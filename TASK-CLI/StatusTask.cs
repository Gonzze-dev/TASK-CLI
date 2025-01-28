using System.Runtime.Serialization;

namespace TASK_CLI
{
    public enum StatusTask
    {
        [EnumMember(Value = "todo")]
        todo,
        [EnumMember(Value = "in-progress")]
        inProgress,
        [EnumMember(Value = "done")]
        done,
    }

}

