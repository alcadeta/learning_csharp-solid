namespace ArdalisRating
{
    public abstract class Rater
    {
        protected ILogger Logger { get; set; }

        public Rater(ILogger logger) => Logger = logger;

        public abstract decimal Rate(Policy policy);
    }
}