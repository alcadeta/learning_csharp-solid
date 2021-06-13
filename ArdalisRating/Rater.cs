namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;
        protected ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater) =>
            _ratingUpdater = ratingUpdater;

        public abstract void Rate(Policy policy);
    }
}