using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public ConsoleLogger Logger { get; set; } = new();
        public FilePolicySource Source { get; set; } = new();
        public JsonPolicySerializer PolicySerializer { get; set; } = new();

        /// <OCP-Note>
        /// Rate method is now open to extension but closed to modification (OCP). We don't need to
        /// change the Rate method in order to add support for a new policy type.
        /// </OCP-Note>
        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            var policyJson = Source.GetPolicySource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
