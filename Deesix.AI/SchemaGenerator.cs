
using NJsonSchema;

namespace Deesix.AI;

public static class SchemaGenerator
{
    public static string GenerateSchema<T>()
    {
        var schema = JsonSchema.FromType<T>();
        return schema.ToJson();
    }
}
