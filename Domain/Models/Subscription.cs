using Refactor2.Domain.Enums;

namespace Refactor2.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public SubscriptionType Type { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
