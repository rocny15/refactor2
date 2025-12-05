using Refactor2.Domain.Enums;
using Refactor2.Domain.Models;
using Refactor2.Interfaces;

namespace Refactor2.Domain.Services
{
    public class SubcriptionCalculation : ISubscriptionCalculation
    {
        public decimal CalculateFinalPrice(Subscription subscription)
        {
            return subscription.Type switch
            {
                SubscriptionType.Monthly => subscription.BasePrice,
                SubscriptionType.Yearly => subscription.BasePrice * 12 * 0.8m,
                SubscriptionType.Trial => 0,
                _ => subscription.BasePrice,
            };         
        }
    }
}
