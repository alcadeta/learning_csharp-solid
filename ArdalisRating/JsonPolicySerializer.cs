using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policy);
    }
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyJson) =>
            JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
    }
}