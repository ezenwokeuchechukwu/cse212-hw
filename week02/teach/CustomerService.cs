public class CustomerService {
    public static void Run() {
        var cs = new CustomerService(2);

        Console.WriteLine("Test 1: Add 2 Customers");
        cs.AddCustomer("Alice", "A001", "Password reset");
        cs.AddCustomer("Bob", "B002", "Cannot log in");
        Console.WriteLine(cs);  // Should show both

        Console.WriteLine("Test 2: Attempt to Add 3rd Customer (should fail)");
        cs.AddCustomer("Charlie", "C003", "Account locked");  // Should print max warning

        Console.WriteLine("Test 3: Serve 1 Customer");
        cs.ServeCustomer();  // Should serve Alice
        Console.WriteLine(cs);

        Console.WriteLine("Test 4: Serve 2nd Customer");
        cs.ServeCustomer();  // Should serve Bob
        Console.WriteLine(cs);

        Console.WriteLine("Test 5: Try Serving from Empty Queue");
        cs.ServeCustomer();  // Should warn: no customers
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = maxSize > 0 ? maxSize : 10;
    }

    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    private void AddCustomer(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        Console.WriteLine("Serving: " + customer);
        _queue.RemoveAt(0);
    }

    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
