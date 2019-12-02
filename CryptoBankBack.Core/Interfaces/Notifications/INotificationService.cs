using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBankBackend.Core.Interfaces
{
    public interface  INotificationService
    {
        public void SendNotification(int userId, string title, string message);
    }
}
