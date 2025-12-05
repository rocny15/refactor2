using Refactor2.Domain.Models;
using Refactor2.Domain.Reponse;

namespace Refactor2.Interfaces
{
    public interface ISubscriptionValidation
    {
        ValidationResult Validate(Subscription subscription);
    }
}
