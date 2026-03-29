//using System.Runtime.Intrinsics.X86;

//Problem 1 – Level 1
//Scenario:
//A small organization wants to store simple log messages into a text file using a C# console application.
//Requirements:
//1.Accept a message from the user.
//2. Write the message into a file using FileStream.
//3.Append multiple messages to the same file.
//4. Display confirmation after writing the data.
//Technical Constraints:
//• Use FileStream class.
//• Use appropriate FileMode and FileAccess.
//• Implement exception handling for file access errors.
//Expectations:
//The application should successfully write user messages to the file and allow multiple entries.
//Learning Outcome:
//Students will learn how to create and write data into files using FileStream.



using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "log.txt";

        while (true)
        {
            Console.Write("\nEnter message (or type 'exit' to stop): ");
            string message = Console.ReadLine();

            if (message.ToLower() == "exit")
                break;

            try
            {
                // Open file in Append mode
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    // Convert string to bytes
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                    // Write data to file
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message saved successfully!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: No permission to access the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        Console.WriteLine("\nAll messages saved. Program ended.");
    }
}