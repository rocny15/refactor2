using Refactor2.Domain.Models;
using Refactor2.Domain.Reponse;
using Refactor2.Interfaces;

namespace Refactor2.Domain.Services
{
    public class SubcriptionValidation : ISubscriptionValidation
    {
        public ValidationResult Validate(Subscription subscription)
        {
            if (subscription == null)
                return new ValidationResult(false, "Subscription is null");

            if (string.IsNullOrEmpty(subscription.CustomerEmail))
                return new ValidationResult(false, "Customer email is required");

            if (subscription.BasePrice <= 0)
                return new ValidationResult(false, "Base price must be greater than 0");
            
            return new ValidationResult(true, string.Empty);
        }
    }
}
