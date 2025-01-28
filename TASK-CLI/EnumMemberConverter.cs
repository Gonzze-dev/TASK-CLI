using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TASK_CLI
{
    public class EnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            foreach (var field in typeof(T).GetFields())
            {
                var attribute = field.GetCustomAttributes(
                    typeof(EnumMemberAttribute), 
                    false
                )
                .Cast<EnumMemberAttribute>()
                .FirstOrDefault();

                if (attribute != null && attribute.Value == value)
                {
                    return (T)field.GetValue(null)!;
                }
            }

            throw new JsonException($"Cant covnert '{value}' to {typeof(T).Name}");
        }

        public override void Write(Utf8JsonWriter writer, 
            T value, 
            JsonSerializerOptions options)
        {
            var field = typeof(T).GetField(value.ToString()!);

            var attribute = field?.GetCustomAttributes(
                typeof(EnumMemberAttribute), 
                false
            )
            .Cast<EnumMemberAttribute>()
            .FirstOrDefault();

            if (attribute != null)
            {
                writer.WriteStringValue(attribute.Value);
            }
            else
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
