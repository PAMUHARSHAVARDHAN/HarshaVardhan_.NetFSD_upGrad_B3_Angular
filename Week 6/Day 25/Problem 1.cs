//using System.Runtime.Intrinsics.X86;

//Level - 1 Problem 1: Asynchronous File Logger
//Scenario:
// An application writes logs to a file whenever an event occurs. Writing logs synchronously can slow down the application. Asynchronous file writing improves performance.

//Requirements:
// -Create an asynchronous method WriteLogAsync(string message).
// - The method should simulate file writing using Task.Delay().
// - Call this method multiple times to simulate logging different events.

//Technical Constraints:
// -Use async and await keywords.
// - Use Task.Delay() to simulate file I/O.
// - Use a console application.

//Expectations:
// -Logs should be written asynchronously.
// - The main thread should remain responsive while logging operations occur.

//Learning Outcome:
// Students will learn how asynchronous operations improve performance when dealing with I/O operations.




using System;
using System.Threading.Tasks;

class Program
{
    // Asynchronous method to simulate file writing
    public static async Task WriteLogAsync(string message)
    {
        Console.WriteLine($"Start Writing: {message}");

        // Simulate file I/O delay (e.g., writing to file)
        await Task.Delay(2000);

        Console.WriteLine($"Finished Writing: {message}");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Application Started...\n");

        // Calling async logging multiple times
        Task log1 = WriteLogAsync("User logged in");
        Task log2 = WriteLogAsync("File uploaded");
        Task log3 = WriteLogAsync("Error occurred");

        // Main thread continues working
        Console.WriteLine("Main thread is free to do other work...\n");

        // Wait for all logging tasks to complete
        await Task.WhenAll(log1, log2, log3);

        Console.WriteLine("\nAll logs written successfully!");
    }
}