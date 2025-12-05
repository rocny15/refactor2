using Refactor2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactor2.Domain.Dtos
{
    public class ProcessSubscriptionDto
    {
        public Subscription Subscription { get; set; }
        public bool EnableLogging { get; set; }
        public bool EnableCaching { get; set; }
        public bool SendWelcomeEmail { get; set; }
        public bool SimulateSlowDatabase { get; set; }
    }
}
