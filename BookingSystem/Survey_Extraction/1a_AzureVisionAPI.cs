//Craig Whelan X00075734

//Azure Vision OCR API call    ***
//stores all returned text in .txt file to be parsed     ***

using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;
using System.Web.Mvc;
using System.Web;


namespace BookingSystem.Survey_Extraction
{
    public static class AzureVisionAPI
    {
        private static string subscriptionKey = Environment.GetEnvironmentVariable("AzureSubscriptionKey");
        private static string endpoint = ("https://computervisionproj.cognitiveservices.azure.com/"); // uploaded PDF is sent to this endpoint
        private static string outfile = HttpContext.Current.Server.MapPath("~/azureAPIresponse.txt"); // all PDF text, including handwritten text that is returned is saved in file

        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
                { Endpoint = endpoint };
            return client;
        }


        public static async Task ExtractToTextFile(string filename)
        {
            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);
            await ExtractTextLocal(client, filename);
        }

        public static async Task ExtractTextLocal(ComputerVisionClient client, string localImage)
        {

            // Helps calucalte starting index to retrieve operation ID
            const int numberOfCharsInOperationId = 36;

            using (Stream imageStream = File.OpenRead(localImage))
            {
                // Read the text from the local image
                BatchReadFileInStreamHeaders localFileTextHeaders = await client.BatchReadFileInStreamAsync(imageStream);
                // Get the operation location (operation ID)
                string operationLocation = localFileTextHeaders.OperationLocation;

                // Retrieve the URI where the recognized text will be stored from the Operation-Location header.
                string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

                // Extract text, wait for it to complete.
                int i = 0;
                int maxRetries = 10;
                ReadOperationResult results;
                do
                {
                    results = await client.GetReadOperationResultAsync(operationId);

                    await Task.Delay(1000);
                    if (maxRetries == 9)
                    {
                        throw new Exception("Azure API timed out");
                    }
                }
                while ((results.Status == TextOperationStatusCodes.Running ||
                        results.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries);

                using (StreamWriter sw = new StreamWriter(outfile))
                {
                    // Loop through data which is returned and save line by line in .txt file ***
                    var textRecognitionLocalFileResults = results.RecognitionResults;
                    foreach (TextRecognitionResult recResult in textRecognitionLocalFileResults)
                    {
                        foreach (Line line in recResult.Lines)
                        {
                            sw.WriteLine(line.Text);
                        }

                    }
                }
            }
        }
    }
}