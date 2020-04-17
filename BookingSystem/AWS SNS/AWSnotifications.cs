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
        private static BasicAWSCredentials credentials = new BasicAWSCredentials("AKIAJRCTPVFB65QC2HOQ", "xwGBCA8UgDgxf7krJH0PAtZlT/9VOvmcCTD9qLiE");

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
//Hi Raj, 
//Apologies for the direct message, and I hope all is well during these worrying times.
//Regarding our interview a couple of weeks ago, I am curious to know if a decision
//has been made yet for this position?
//The projects which were mentioned by Thomas seem extremely interesting, and I would really like to 
//be a part of them after I graduate. I feel that my tech stack, AWS in particular is a perfect match for the team, 
//so it would be great to come on board.