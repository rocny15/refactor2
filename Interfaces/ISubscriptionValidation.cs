using Refactor2.Domain.Models;
namespace Refactor2.Interfaces
{
    public interface ISubscriptionValidation
    {
        (bool isValid, string erroMessage) Validate(Subscription subscription);
    }
}
