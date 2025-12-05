using Refactor2.Domain.Models;
using Refactor2.Interfaces;

namespace Refactor2.Domain.Services
{
    public class SubcriptionValidation : ISubscriptionValidation
    {
        public (bool isValid, string erroMessage) Validate(Subscription subscription)
        {
            if (subscription == null)
                return (false, "Subscription is null");

            if (string.IsNullOrEmpty(subscription.CustomerEmail))
                return (false, "Customer email is required");

            if (subscription.BasePrice <= 0)
                return (false, "Base price must be greater than 0");
            
            return (true, string.Empty);
        }
    }
}
