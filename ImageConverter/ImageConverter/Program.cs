using System;
using System.IO;

namespace ImageConverter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Instructions: Run image converter from the folder of the images you'd like to convert.");

            var filePath = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine("Running Image Converter...");

            string[] files = Directory.GetFiles(filePath, "*.heic", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var convertedFile = Path.ChangeExtension(file, ".jpeg");
                System.IO.File.Move(file, convertedFile);
                Console.WriteLine("Converting {0} to {1}", file, convertedFile);
            }

            Console.WriteLine("Done!");
        }
    }
}
