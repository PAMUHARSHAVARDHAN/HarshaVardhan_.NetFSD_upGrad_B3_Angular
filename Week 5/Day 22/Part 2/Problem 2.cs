//Level - 2 Problem 2: Employee Management Using Linked List
//Scenario:	
//A company wants to maintain employee records dynamically using a Linked List structure.
//Requirements:
//-Create Node structure with employee ID and name.
//- Implement insertion at beginning and end.
//- Implement deletion by employee ID.
//- Traverse and display employee list.
//Technical Constraints:
//-Must implement singly linked list.
//- No use of built-in list structures.
//- Proper memory handling and pointer updates.
//Sample Input:
//Insert: (101, John), (102, Sara), (103, Mike)
//Delete: 102
//Sample Output:
//Employee List After Deletion:
//101 - John
//103 – Mike
//Expectations:
//-Correct node linking.
//-Efficient traversal logic.
//-Clean insertion and deletion operations.
//Learning Outcome:
//-Understand linked list structure.
//- Perform insertion and deletion operations.
//- Learn dynamic data structure behavior.


using System;

// Node structure
class Node
{
    public int Id;
    public string Name;
    public Node Next;

    public Node(int id, string name)
    {
        Id = id;
        Name = name;
        Next = null;
    }
}

// Linked List class
class EmployeeLinkedList
{
    private Node head;

    // Insert at Beginning
    public void InsertAtBeginning(int id, string name)
    {
        Node newNode = new Node(id, name);
        newNode.Next = head;
        head = newNode;
    }

    // Insert at End
    public void InsertAtEnd(int id, string name)
    {
        Node newNode = new Node(id, name);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
    }

    // Delete by ID
    public void Delete(int id)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        // If head needs to be deleted
        if (head.Id == id)
        {
            head = head.Next;
            Console.WriteLine($"Employee {id} deleted.");
            return;
        }

        Node current = head;
        Node previous = null;

        while (current != null && current.Id != id)
        {
            previous = current;
            current = current.Next;
        }

        if (current == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        // Remove node
        previous.Next = current.Next;
        Console.WriteLine($"Employee {id} deleted.");
    }

    // Display list
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Id} - {temp.Name}");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeLinkedList list = new EmployeeLinkedList();

        // Sample Input
        list.InsertAtEnd(101, "John");
        list.InsertAtEnd(102, "Sara");
        list.InsertAtEnd(103, "Mike");

        Console.WriteLine("Initial Employee List:");
        list.Display();

        // Delete operation
        Console.WriteLine("\nDeleting Employee with ID 102...");
        list.Delete(102);

        Console.WriteLine("\nEmployee List After Deletion:");
        list.Display();
    }
}
