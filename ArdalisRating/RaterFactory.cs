using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] { engine, engine.Logger });
            }
            catch
            {
                return new UnknownPolicyRater(engine, engine.Logger);
            }
        }
        /* OCP-Note:
         * By replacing this block of code, which was the body of the Create method above
         * previously, we even make the Factory open to extension but closed to modification,
         * eliminating the need to modify the code to add a new case
         *
         * => policy.Type switch
         * {
         *     PolicyType.Auto => new AutoPolicyRater(engine, engine.Logger),
         *     PolicyType.Land => new LandPolicyRater(engine, engine.Logger),
         *     PolicyType.Life => new LifePolicyRater(engine, engine.Logger),
         *     PolicyType.Flood => new FloodPolicyRater(engine, engine.Logger),
         *     _ => throw new NotSupportedException()
         * };
         */
    }
}