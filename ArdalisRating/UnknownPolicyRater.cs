namespace ArdalisRating
{
    /// By using type instead of null, we avoid dealing with nulls and comply
    /// with the Liskov Substitution Principle.
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger)
            : base(engine, logger)
        {
        }

        public override void Rate(Policy policy) =>
            _logger.Log("Unknown policy type.");
    }
}