using Refactor2.Domain.Models;
using Refactor2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactor2.Domain.Services
{
    public class CachingSuscriptionCalculation : ISubscriptionCalculation
    {
        private readonly ISubscriptionCalculation _inner;
        private readonly Dictionary<int, decimal> _cache = [];

        public CachingSuscriptionCalculation(ISubscriptionCalculation inner)
        {
            _inner = inner;
        }

        public decimal CalculateFinalPrice(Subscription subscription)
        {
            if (_cache.TryGetValue(subscription.Id, out var cachePrice))
            {
                Console.WriteLine($"[LOG] Found price in cache for subscription {subscription.Id}");
                return cachePrice;
            }

            var finalPrice = _inner.CalculateFinalPrice(subscription);
            _cache[subscription.Id] = finalPrice;
            return finalPrice;
        }
    }
}
