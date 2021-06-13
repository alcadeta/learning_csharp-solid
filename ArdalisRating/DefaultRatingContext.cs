using System;

namespace ArdalisRating
{
    public class DefaultRatingContext : IRatingContext
    {
        public RatingEngine Engine { get; set; }

        private readonly IPolicySource _policySource;

        private readonly IPolicySerializer _policySerializer;

        private readonly ILogger _logger;

        public DefaultRatingContext(IPolicySource policySource,
            IPolicySerializer policySerializer,
            ILogger logger)
        {
            _policySource = policySource;
            _policySerializer = policySerializer;
            _logger = logger;
        }

        public ConsoleLogger Logger => new ConsoleLogger();

        public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
        {
            return new RaterFactory(_logger).Create(policy);
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return _policySerializer.GetPolicyFromString(policyJson);
        }

        public Policy GetPolicyFromXmlString(string policyXml)
        {
            throw new NotImplementedException();
        }

        public string LoadPolicyFromFile()
        {
            return _policySource.GetPolicyFromSource();
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }

        public void UpdateRating(decimal rating)
        {
            Engine.Rating = rating;
        }
    }
}