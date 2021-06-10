using System.IO;

namespace ArdalisRating
{
    public class FilePolicySource
    {
        public string GetPolicySource() => File.ReadAllText("policy.json");
    }
}