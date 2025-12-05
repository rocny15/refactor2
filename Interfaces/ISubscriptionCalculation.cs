using Refactor2.Domain.Models;

namespace Refactor2.Interfaces
{
    public interface ISubscriptionCalculation
    {
        decimal CalculateFinalPrice(Subscription subscription);
    }
}
