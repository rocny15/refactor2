using Refactor2.Domain.Dtos;
using Refactor2.Domain.Enums;
using Refactor2.Domain.Models;
using Refactor2.Interfaces;
using System.Diagnostics;

namespace Refactor2.Domain.Services
{  
    public class SubscriptionService(
        ISubscriptionValidation subscriptionValidation, 
        ISubscriptionCalculation subscriptionCalculation, 
        INotificationServices notificationServices)
    {
        private readonly ISubscriptionValidation _subscriptionValidation = subscriptionValidation;
        private readonly ISubscriptionCalculation _subscriptionCalculation = subscriptionCalculation;
        private readonly INotificationServices _notificationServices = notificationServices; 

        public void ProcessSubscription(ProcessSubscriptionDto subscriptionDto)
        {
            var subscription = subscriptionDto.Subscription;
            var result = _subscriptionValidation.Validate(subscription);

            if (!result.IsValid)
            {
                Console.WriteLine(result.ErrorMessage);
                return;
            }

            Stopwatch sw = null;
            if (subscriptionDto.EnableLogging)
            {
                Console.WriteLine($"[LOG] Start processing subscription {subscription.Id}");
                sw = Stopwatch.StartNew();
            }

            var finalPrice = _subscriptionCalculation.CalculateFinalPrice(subscription);

            if (subscriptionDto.SimulateSlowDatabase)
            {
                Thread.Sleep(500); // simulate DB latency
            }

            // "DB" write
            var line = $"{subscription.Id};{subscription.CustomerEmail};{subscription.Type};{finalPrice};{subscription.CreatedAt}";
            File.AppendAllLines("subscriptions_db.txt", new[] { line });

            if (subscriptionDto.SendWelcomeEmail)
                _notificationServices.SendEmail(subscription.CustomerEmail, finalPrice);

            if (subscriptionDto.EnableLogging && sw != null)
            {
                sw.Stop();
                Console.WriteLine($"[LOG] Subscription {subscription.Id} processed in {sw.ElapsedMilliseconds} ms");
            }
        }

        public void GenerateReport(List<Subscription> subscriptions)
        {
            decimal totalMonthly = 0;
            decimal totalYearly = 0;
            decimal totalTrial = 0;

            int monthlyCount = 0;
            int yearlyCount = 0;
            int trialCount = 0;

            foreach (var sub in subscriptions)
            {
                var price = _subscriptionCalculation.CalculateFinalPrice(sub);

                switch (sub.Type)
                {
                    case SubscriptionType.Monthly:
                        monthlyCount++;
                        totalMonthly += price;
                        break;

                    case SubscriptionType.Yearly:
                        yearlyCount++;
                        totalYearly += price;
                        break;

                    case SubscriptionType.Trial:
                        trialCount++;
                        totalTrial += price;
                        break;
                }
            }

            Console.WriteLine("=== SUBSCRIPTIONS REPORT ===");
            Console.WriteLine($"Monthly  : {monthlyCount} | Total: {totalMonthly}");
            Console.WriteLine($"Yearly   : {yearlyCount}  | Total: {totalYearly}");
            Console.WriteLine($"Trial    : {trialCount}   | Total: {totalTrial}");
        }
    }
}
