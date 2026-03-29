//using System.Runtime.Intrinsics.X86;

//Problem 4 – Level 2
//Scenario:
//A development team wants to analyze all folders inside a project directory to understand the project structure.
//Requirements:
//1.Accept a root directory path.
//2. Display all subdirectories inside the root folder.
//3. Show the number of files present in each directory.
//Technical Constraints:
//• Use DirectoryInfo class.
//• Use loops to iterate through directories.
//• Implement exception handling.
//Expectations:
//The application should display folder names and file counts for each directory.
//Learning Outcome:
//Students will learn how to navigate directories and retrieve folder information using DirectoryInfo.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter root directory path: ");
        string path = Console.ReadLine();

        try
        {
            // Validate directory
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            DirectoryInfo root = new DirectoryInfo(path);

            Console.WriteLine("\nSubdirectories and File Counts:\n");

            // Get all subdirectories
            DirectoryInfo[] directories = root.GetDirectories();

            if (directories.Length == 0)
            {
                Console.WriteLine("No subdirectories found.");
                return;
            }

            foreach (DirectoryInfo dir in directories)
            {
                try
                {
                    // Count files in each directory
                    FileInfo[] files = dir.GetFiles();
                    Console.WriteLine($"Folder: {dir.Name} | Files: {files.Length}");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Folder: {dir.Name} | Access Denied");
                }
            }
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

