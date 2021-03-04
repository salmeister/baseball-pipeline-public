using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebPush;

namespace BaseballPipeline.Server.Services
{
    public class NotificationSender
    {
        public async Task SendNotificationAsync(string message)
        {
            var publicKey = "BIqnDgGJw21BYVOZ1D_73qdmaIH_dDNbcxE4Z7ty7_YcvmaJ5IwQ8FWk_G9tc61dAb4Rv4MKU-2O9QH_7h1s06U";
            var privateKey = "OHTekpjNE9LK2EwgVDn2F7XNJbMyKtclUuxRLTbcg6U";

            

            //var pushSubscription = new PushSubscription(subscription.Url, subscription.P256dh, subscription.Auth);
            var pushSubscription = new PushSubscription("https://fcm.googleapis.com/fcm/send/cGE_deYxFX0:APA91bF4BhmmqtFfolGzqA7Q1cy89soC6N3e2E6BrIkusFdcDwc3CbDUuVuwJ3AKmD9LI-vUlnkxnOEGHfY9sSeubZaJweXyZDa7kc3YkcYlqEkLbPN9RkkB8pMeKaDmCxvOOr_f3qt6", "BP8ka8Sq/fYI9Zj3AZ0HnN7csVDNilRsidYq0H27Iw1JoYvcyn0oTIuoF5cNJwmeihvRWpw5N+YoOgKiylm6suo=", "BJJaj+cZwNQoVFWBktm5iw==");
            var vapidDetails = new VapidDetails("mailto:andrewsalmela@gmail.com", publicKey, privateKey);
            var webPushClient = new WebPushClient();
            try
            {
                var payload = JsonSerializer.Serialize(new
                {
                    message,
                    url = "https://baseball-pipeline",
                });
                await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error sending push notification: " + ex.Message);
            }
        }
    }
}
