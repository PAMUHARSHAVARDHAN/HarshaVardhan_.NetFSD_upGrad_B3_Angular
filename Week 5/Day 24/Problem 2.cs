//using System.Reflection.Metadata;
//using System.Runtime.Intrinsics.X86;

//Problem 2 – Level 1:
//Scenario:
//An administrator wants to check file properties stored in a particular folder for auditing purposes.
//Requirements:
//1.Accept a folder path from the user.
//2. Display file name, file size, and creation date.
//3. Count and display the total number of files.
//Technical Constraints:
//• Use FileInfo class.
//• Handle invalid directory paths.
//Expectations:
//The program should list file details clearly in the console.
//Learning Outcome:
//Students will understand how to retrieve file metadata using FileInfo.


using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter folder path: ");
        string folderPath = Console.ReadLine();

        try
        {
            // Check if directory exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            // Get all files
            string[] files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                Console.WriteLine("No files found in this directory.");
                return;
            }

            Console.WriteLine("\nFile Details:\n");

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                Console.WriteLine($"Name : {info.Name}");
                Console.WriteLine($"Size : {info.Length} bytes");
                Console.WriteLine($"Created On : {info.CreationTime}");
                Console.WriteLine("----------------------------------");
            }

            // Total count
            Console.WriteLine($"\nTotal Files: {files.Length}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied! You don’t have permission.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}