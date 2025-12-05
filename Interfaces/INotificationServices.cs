using System;
using System.Collections.Generic;
using System.Text;

namespace Refactor2.Interfaces
{
    public interface INotificationServices
    {
        void SendEmail(string email, decimal finalPrice);
    }
}
