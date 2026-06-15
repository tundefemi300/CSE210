using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Phoenix",
            "Arizona",
            "USA");

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P101", 800, 1));
        order1.AddProduct(new Product("Mouse", "P102", 25, 2));
        order1.AddProduct(new Product("Keyboard", "P103", 50, 1));

        Address address2 = new Address(
            "45 King Road",
            "Toronto",
            "Ontario",
            "Canada");

        Customer customer2 = new Customer("Sarah Johnson", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "P201", 250, 1));
        order2.AddProduct(new Product("Headphones", "P202", 75, 2));

        Console.WriteLine("ORDER 1");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}