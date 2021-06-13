using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
                Logger.Log("Auto policy must specify Make");

            if (policy.Make == "BMW")
                return policy.Deductible < 500 ? 1000m : 900m;

            return 0m;
        }
    }
}