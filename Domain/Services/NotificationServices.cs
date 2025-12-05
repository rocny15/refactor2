using Refactor2.Domain.Models;
using Refactor2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactor2.Domain.Services
{
    public class NotificationServices : INotificationServices
    {
        public void SendEmail(string email, decimal finalPrice)
        {
            Console.WriteLine($"[EMAIL] To: {email} | Welcome! Your price is {finalPrice}");
        }
    }
}
