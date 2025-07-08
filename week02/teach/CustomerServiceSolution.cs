using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerServiceSolution
{
    public static void Run()
    {
        Console.WriteLine("Test 1");
        var service = new CustomerServiceSolution(4);
        service.AddNewCustomer();
        service.ServeCustomer();

        Console.WriteLine("=================");

        Console.WriteLine("Test 2");
        service = new CustomerServiceSolution(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");

        Console.WriteLine("=================");

        Console.WriteLine("Test 3");
        service = new CustomerServiceSolution(4);
        service.ServeCustomer();

        Console.WriteLine("=================");

        Console.WriteLine("Test 4");
        service = new CustomerServiceSolution(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer(); // Should trigger max size error
        Console.WriteLine($"Service Queue: {service}");

        Console.WriteLine("=================");

        Console.WriteLine("Test 5");
        service = new CustomerServiceSolution(0); // Should default to size 10
        Console.WriteLine($"Size should be 10: {service}");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerServiceSolution(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    private void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    private void ServeCustomer()
    {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No Customers in the queue");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
