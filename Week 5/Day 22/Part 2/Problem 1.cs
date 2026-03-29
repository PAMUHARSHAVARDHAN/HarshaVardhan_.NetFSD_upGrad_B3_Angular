

//Level - 1 Problem 1: Stack - Based Undo System
//Scenario:
//Design a simple text editor undo feature using Stack (LIFO principle).
//Requirements:
//-Implement stack using arrays.
//-Support push(add action) and pop(undo action).
//-Display current state after each operation.
//Technical Constraints:
//-Only array - based stack implementation.
//-Must follow LIFO order strictly.
//- Handle empty stack condition.
//Sample Input:
//Actions: Type A, Type B, Type C, Undo, Undo
//Sample Output:
//Current State After Operations: Type A
//Expectations:
//-Correct LIFO implementation.
//-Proper error handling.
//-Clear logic structure.


//Learning Outcome:
//-Understand stack operations.
//-Learn LIFO principle application.
//- Implem


using System;

class StackUndo
{
    private string[] stack;
    private int top;
    private int capacity;

    public StackUndo(int size)
    {
        capacity = size;
        stack = new string[capacity];
        top = -1;
    }

    // Push operation (Add action)
    public void Push(string action)
    {
        if (top == capacity - 1)
        {
            Console.WriteLine("Stack Overflow! Cannot add more actions.");
            return;
        }

        stack[++top] = action;
        Console.WriteLine($"Action Performed: {action}");
        Display();
    }

    // Pop operation (Undo action)
    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow! Nothing to undo.");
            return;
        }

        Console.WriteLine($"Undo Action: {stack[top]}");
        top--;
        Display();
    }

    // Display current state
    public void Display()
    {
        Console.Write("Current State: ");

        if (top == -1)
        {
            Console.WriteLine("Empty");
            return;
        }

        for (int i = 0; i <= top; i++)
        {
            Console.Write(stack[i] + " ");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        StackUndo editor = new StackUndo(10);

        // Sample operations
        editor.Push("Type A");
        editor.Push("Type B");
        editor.Push("Type C");

        editor.Pop(); // Undo
        editor.Pop(); // Undo

        Console.WriteLine("\nFinal State After Operations:");
        editor.Display();
    }
}