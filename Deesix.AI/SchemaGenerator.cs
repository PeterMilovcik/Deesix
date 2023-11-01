using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace Deesix.AI;

public static class SchemaGenerator
{
    public static string GenerateSchema<T>()
    {
        JSchemaGenerator generator = new JSchemaGenerator();
        JSchema schema = generator.Generate(typeof(T));
        return schema.ToString();
    }
}
