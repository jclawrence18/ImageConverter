using System;
using System.Collections.Generic;
using System.IO;

namespace ImageConverter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Array of supported file types
            string[] fileTypes = new string[]
            {
                "HEIC",
                "JPEG",
                "PNG"
            };

            Console.WriteLine("Instructions: Run image converter from the folder of the images you'd like to convert." + Environment.NewLine);

            // Gets the directory the exe is being run from
            var filePath = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine("Select an image type to convert:"
                + Environment.NewLine);

            PrintFileTypes(fileTypes);

            Console.WriteLine(Environment.NewLine);
            Console.Write("Enter Number: ");

            // Get file type to convert from user
            int numToConvert = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select the image type you would like to convert to:"
                + Environment.NewLine);

            PrintFileTypes(fileTypes);

            Console.WriteLine(Environment.NewLine);
            Console.Write("Enter Number: ");

            int convertToNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Running Image Converter...");
            ConvertImageTypes(numToConvert, convertToNum, fileTypes, filePath);

            Console.WriteLine("Done!");
        }

        static void PrintFileTypes(string[] fileTypes)
        {
            foreach (var file in fileTypes)
            {
                Console.WriteLine(string.Format("{0}. {1}",
                    Array.FindIndex(fileTypes, s => s == file) + 1,
                    file));
            }
        }

        static void ConvertImageTypes(int numToConvert,
            int convertToNum,
            string[] fileTypes, string filePath)
        {
            // Get file type at index (convert num - 1)
            var typeToConvert = fileTypes[numToConvert - 1];
            var convertToType = fileTypes[convertToNum - 1];

            string[] files = Directory.GetFiles(filePath, typeToConvert, SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var convertedFile = Path.ChangeExtension(file, convertToType);
                System.IO.File.Move(file, convertedFile);
                Console.WriteLine("Converting {0} to {1}", file, convertedFile);
            }
        }
    }
}
