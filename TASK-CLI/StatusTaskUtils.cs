using System.Runtime.Serialization;

namespace TASK_CLI
{
    public static class StatusTaskUtils
    {
        public static string GetEnumMemberValue<T>(T enumValue) where T : Enum
        {
            var type = typeof(T);
            var memberInfo = type.GetMember(enumValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((EnumMemberAttribute)attributes[0]).Value!;
                }
            }

            return enumValue.ToString();  // Retorna el nombre del enum si no tiene el atributo [EnumMember]
        }

        public static StatusTask? GetEnumByStringValue(string statusString)
        {
            var statusTaskDic = new Dictionary<string, StatusTask>
            {
                { "todo", StatusTask.todo },
                { "in-progress", StatusTask.inProgress },
                { "done", StatusTask.done },
             };

            StatusTask status;

            var existKey = statusTaskDic.TryGetValue(statusString, out status);

            if (!existKey)
                return null;

            return status;
        }
    }
}
