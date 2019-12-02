using CryptoBankBackend.Core.Interfaces;
using OneSignal.CSharp.SDK;
using OneSignal.CSharp.SDK.Resources;
using OneSignal.CSharp.SDK.Resources.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CryptoBankBackend.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private OneSignalClient _clientOneSignal = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public NotificationService()
        {

        }

        #endregion

        #region ----- INTERFACE METHODS -----------------------------------------------

        public void SendNotification(int userId, string title, string message)
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic MjE0ZTBmODctMjliMS00ZDJjLWI5M2YtMDUyZGI1NTg0N2Vh");

            byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                    + "\"app_id\": \"4cc3317e-060c-4e32-bd5d-b01b9adfcf5e\","
                                                    + "\"contents\": {\"en\": \"" + message + "\"},"
                                                    + "\"filters\": [{\"field\": \"tag\", \"key\": \"UserId\", \"relation\": \"=\", \"value\": \"" + userId + "\"}]}");

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }
        }

        #endregion
    }
}
