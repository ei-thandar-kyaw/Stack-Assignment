using System;

public class mySKU
{
    private const int _maxSize = 100;
    private int _top;
    private string[] _skuName;

    public mySKU()
    {
        _skuName = new string[_maxSize];
        _top = -1;
    }

    public void Insert(string skuName)
    {
        if (_top == _maxSize - 1)
        {
            Console.WriteLine("Reached maximum limit. Cannot add anymore.");
            return;
        }
        _top++;
        _skuName[_top] = skuName;
        Console.WriteLine(skuName + " has been added to the database.");
    }

    public void Delete()
    {
        if (_top == -1)
        {
            Console.WriteLine("There are no more SKUs to delete.");
            return;
        }
        string skuToRemove = _skuName[_top];
        _top--;
        Console.WriteLine(skuToRemove + " has been removed.");
    }

    public void Search(string skuName)
    {
        bool found = false;
        for (int i = 0; i <= _top; i++)
        {
            if (_skuName[i] == skuName)
            {
                Console.WriteLine("SKU '" + skuName + "' found at position " + i + " (from bottom).");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("SKU '" + skuName + "' not found in the stack.");
        }
    }

    public void Display()
    {
        if (_top == -1)
        {
            Console.WriteLine("SKU stack is empty.");
            return;
        }

        Console.WriteLine("Current SKUs in stack:");
        for (int i = _top; i >= 0; i--)
        {
            Console.WriteLine("- " + _skuName[i]);
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        mySKU skuStack = new mySKU();
        string input;

        Console.WriteLine("ADD SKUS TO YOUR E-FMCG DATABASE");

        Console.WriteLine("***Type any SKU name to add, 'Done' to display all SKUs, 'Delete' to remove last SKU, 'Search' to find a SKU, 'Exit' to exit the program***");

        while (true)
        {
            Console.Write("Enter SKU Name or Command: ");
            input = Console.ReadLine();

            if (input == "Exit")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
            else if (input == "Done")
            {
                skuStack.Display();
            }
            else if (input == "Delete")
            {
                skuStack.Delete();
            }
            else if (input == "Search")
            {
                Console.Write("Enter SKU to search: ");
                string skuSearch = Console.ReadLine();
                skuStack.Search(skuSearch);
            }
            else
            {
                skuStack.Insert(input);
            }
        }
    }
}
