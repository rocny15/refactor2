using Refactor2.Domain.Dtos;
using Refactor2.Domain.Models;

namespace Refactor2.Interfaces
{
    internal interface ISubscriptionService
    {
        public void ProcessSubscription(ProcessSubscriptionDto subscriptionDto);
        void GenerateReport(List<Subscription> subs);
    }
}
