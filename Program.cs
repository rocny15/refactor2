using Refactor2.Domain.Enums;
using Refactor2.Domain.Models;
using Refactor2.Domain.Services;

internal class Program
{
    static void Main(string[] args)
    {
        var validation = new SubcriptionValidation();
        var calculation = new SubcriptionCalculation();
        var notification = new NotificationServices();
        var service = new SubscriptionService(validation,calculation, notification);

        var subscriptions = new List<Subscription>
            {
                new() {
                    Id = 1,
                    CustomerEmail = "a@test.com",
                    BasePrice = 10,
                    Type = SubscriptionType.Monthly,
                    CreatedAt = DateTime.Now
                },
                new() {
                    Id = 2,
                    CustomerEmail = "b@test.com",
                    BasePrice = 15,
                    Type = SubscriptionType.Yearly,
                    CreatedAt = DateTime.Now
                },
                new() {
                    Id = 3,
                    CustomerEmail = "c@test.com",
                    BasePrice = 5,
                    Type = SubscriptionType.Trial,
                    CreatedAt = DateTime.Now
                },
            };

        foreach (var sub in subscriptions)
        {
            service.ProcessSubscription(
                new Refactor2.Domain.Dtos.ProcessSubscriptionDto
                {
                    Subscription = sub,
                    EnableLogging = true,
                    EnableCaching = true,
                    SendWelcomeEmail = true,
                    SimulateSlowDatabase = false
                }
            );
        }

        service.GenerateReport(subscriptions);

        Console.WriteLine("Done.");
        Console.ReadLine();
    }
}