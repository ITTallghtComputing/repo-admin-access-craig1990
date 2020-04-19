using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace BookingSystem.AWS_SNS
{
    public static class AWSnotifications
    {
        private static string topicArn = "arn:aws:sns:eu-west-1:725603166205:CSincBooking";
        private static string AWSaccessKey = System.Web.Configuration.WebConfigurationManager.AppSettings["AWSaccessKey"];
        private static string AWSprivateKey = System.Web.Configuration.WebConfigurationManager.AppSettings["AWSprivateKey"];
        private static BasicAWSCredentials credentials = new BasicAWSCredentials(AWSaccessKey, AWSprivateKey);

        //publish request to AWS Simple Notification Service Topic, which will alert subscribers of camp booking by email/phone
        public static void SendBookingNotification(string schoolName, DateTime? date, string campLecturer)
        {
            var snsClient = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.EUWest1);

            //convert nullable DateTime? to DateTime 
            DateTime? t1 = date;
            DateTime t2;
            t2 = (DateTime)t1;
            var emailDate = t2.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            snsClient.Publish(new PublishRequest
            {
                Subject = "CSinc Camp Booking",
                Message = $"New CSinc Camp Booking - School/Organisation: {schoolName}. Date: {emailDate}. Camp Leader: {campLecturer}",
                TopicArn = topicArn
            });

        }
    }
}
