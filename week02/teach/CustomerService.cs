using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Checking to make sure when service queue is created with size <= 0 that it sets 10 as the size
        // Expected Result: Queue with size 10 that can be enqueued and dequeued
        Console.WriteLine("Test 1");

        var csq = new CustomerService(0);

        csq.AddNewCustomer();
        Console.WriteLine(csq);
        csq.ServeCustomer();
        Console.WriteLine(csq);



        // Defect(s) Found: In the serve customer function the .removeAt() was placed before the other lines and that did not allow
        // for the same variable to be used, as it was removed. 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Checking what happens when it is empty
        // Expected Result: Error messages indicating if the queue is empty
        Console.WriteLine("Test 2");

        var customerQueue = new CustomerService(1);

        customerQueue.AddNewCustomer();
        Console.WriteLine(customerQueue);
        customerQueue.ServeCustomer();
        customerQueue.ServeCustomer();
        Console.WriteLine(customerQueue);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 2
        // Scenario: Checking what happens when it is full
        // Expected Result: Error messages indicating if the queue is full
        Console.WriteLine("Test 3");

        var customerQueue2 = new CustomerService(1);

        customerQueue2.AddNewCustomer();
        customerQueue2.AddNewCustomer();

        // Defect(s) Found: 

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
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

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}