using Dapper;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace testIDBcon.Model
{
    public class JsonTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override T Parse(object value)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value=JsonSerializer.Serialize(value);
        }
    }
}
