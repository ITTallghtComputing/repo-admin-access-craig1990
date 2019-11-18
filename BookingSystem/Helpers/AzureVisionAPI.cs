using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace BookingSystem.Helpers
{
    static class AzureVisionAPI
    {
        static string subscriptionKey = ("ce1824b42f79415fafd2b2dabe3081c9");
        static string endpoint = ("https://computervisionproj.cognitiveservices.azure.com/");

        private const string EXTRACT_TEXT_LOCAL_IMAGE = "survey2.jpg";

        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
                { Endpoint = endpoint };
            return client;
        }


        public static void ExtractToTextFile()
        {
            FileStream filestream = new FileStream("out.txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);

            Console.WriteLine("Azure Cognitive Services Computer Vision - .NET quickstart example");
            Console.WriteLine();

            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);

            //ExtractTextUrl(client, EXTRACT_TEXT_URL_IMAGE).Wait();
            ExtractTextLocal(client, EXTRACT_TEXT_LOCAL_IMAGE).Wait();
        }

        public static async Task ExtractTextLocal(ComputerVisionClient client, string localImage)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("EXTRACT TEXT - LOCAL IMAGE");
            Console.WriteLine();

            // Helps calucalte starting index to retrieve operation ID
            const int numberOfCharsInOperationId = 36;

            Console.WriteLine($"Extracting text from local image {Path.GetFileName(localImage)}...");
            Console.WriteLine();
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
                    Console.WriteLine("Server status: {0}, waiting {1} seconds...", results.Status, i);
                    await Task.Delay(1000);
                    if (maxRetries == 9)
                    {
                        Console.WriteLine("Server timed out.");
                    }
                }
                while ((results.Status == TextOperationStatusCodes.Running ||
                        results.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries);

                // Display the found text.
                Console.WriteLine();
                var textRecognitionLocalFileResults = results.RecognitionResults;
                foreach (TextRecognitionResult recResult in textRecognitionLocalFileResults)
                {
                    foreach (Line line in recResult.Lines)
                    {
                        Console.WriteLine(line.Text);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}