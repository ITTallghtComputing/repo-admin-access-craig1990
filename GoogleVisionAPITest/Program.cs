using System;
using System.Linq;
using Google.Cloud.Vision.V1;

namespace GoogleVisionAPITest
{
    public class GoogleTest
    {

        public static void Main(string[] args)
        {

            string credential_path = @"C:\Users\35385\nodal.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            // Instantiates a client
            var client = ImageAnnotatorClient.Create();
            // Load the image file into memory
            var image = Image.FromFile("vision3.jpg");
            // Performs text detection on the image file
            var response = client.DetectDocumentText(image);

            string words = "";

            foreach (var page in response.Pages)
            {
                foreach (var block in page.Blocks)
                {
                    string box = string.Join(" - ", block.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                    // Console.WriteLine($"Block {block.BlockType} at {box}");
                    foreach (var paragraph in block.Paragraphs)
                    {
                        box = string.Join(" - ", paragraph.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                        //Console.WriteLine($"  Paragraph at {box}");
                        foreach (var word in paragraph.Words)
                        {
                            //Console.WriteLine($"    Word: {string.Join("", word.Symbols.Select(s => s.Text))}");
                            words += $" {string.Join("", word.Symbols.Select(s => s.Text))}";
                        }
                    }
                }
            }


            Console.WriteLine(words);


        }
    }
}