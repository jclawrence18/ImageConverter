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

            Console.WriteLine("Running from {0}", filePath);
            
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

            #region metadata method - will complete later
            //Console.WriteLine("Do you want to include image metadata?" + Environment.NewLine +
            //    "WARNING: You will not be able to recover the metadata after conversion");
            //Console.Write("[Y/N]: ");

            //string userResponse = Console.ReadLine();
            //bool transferMetadata = true;

            //if(userResponse.ToLower().Contains("f"))
            //{
            //    transferMetadata = false;
            //}
            #endregion



            Console.WriteLine("Running Image Converter...");

            try
            {
                ConvertImageTypes(numToConvert, convertToNum, fileTypes, filePath);//, transferMetadata);
            }

            catch(Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.InnerException);
            }

            Console.WriteLine("Done!" + Environment.NewLine + "Press any key to close...");
            Console.ReadKey();
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
            string[] fileTypes, string filePath)//,
            //bool transferMetadata)
        {
            // Get file type at index (convert num - 1)
            var typeToConvert = fileTypes[numToConvert - 1];
            var convertToType = fileTypes[convertToNum - 1];

            Console.WriteLine("Converting from {0} to {1}", typeToConvert, convertToType);


            // Check for upper and lowercase file extensions
            string[] filesUpper = Directory.GetFiles(filePath, typeToConvert, SearchOption.AllDirectories);
            string[] filesLower = Directory.GetFiles(filePath, typeToConvert.ToLower(), SearchOption.AllDirectories);

            // Debug lines
            Console.WriteLine(filesUpper.Length);
            Console.WriteLine(filesLower.Length);

            // Concat arrays
            var allFiles = new string[filesUpper.Length + filesLower.Length];
            filesUpper.CopyTo(allFiles, 0);
            filesLower.CopyTo(allFiles, filesUpper.Length);

            foreach (var file in allFiles)
            {
                var convertedFile = Path.ChangeExtension(file, convertToType);
                System.IO.File.Move(file, convertedFile);
                Console.WriteLine("Converting {0} to {1}", file, convertedFile);
            }
        }
    }
}
