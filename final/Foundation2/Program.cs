using System;

class Program
{
    static void Main()
    {
        // Create a sample product
        Product product = new Product("Laptop", 999.99);

        // Create a sample address
        Address address = new Address("123 Main St", "Cityville", "State", "12345");

        // Create a sample customer
        Customer customer = new Customer("John Doe", "john@example.com", address);

        // Create an order
        Order order = new Order(customer);
        order.AddProduct(product, 2); // Add 2 laptops to the order

        // Display order details
        Console.WriteLine("Order Details:");
        Console.WriteLine(order.GenerateOrderSummary());

        // Display shipping label
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GenerateShippingLabel());
    }
}

class Product
{
    private string name;
    private double price;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string ZipCode
    {
        get { return zipCode; }
        set { zipCode = value; }
    }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}

class Customer
{
    private string name;
    private string email;
    private Address address;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public Customer(string name, string email, Address address)
    {
        Name = name;
        Email = email;
        Address = address;
    }
}

class Order
{
    private Customer customer;
    private int orderId;
    private static int nextOrderId = 1;
    private readonly DateTime orderDate;
    private readonly double shippingCostRate = 0.1; // 10% of total cost

    public Order(Customer customer)
    {
        this.customer = customer;
        orderId = nextOrderId++;
        orderDate = DateTime.Now;
    }

    public void AddProduct(Product product, int quantity)
    {
        // Add product and quantity to the order
        // (You can implement this method according to your requirements)
    }

    public double CalculateTotalCost()
    {
        // Calculate the total cost of the order
        // (You can implement this method according to your requirements)
        return 0.0;
    }

    public string GenerateOrderSummary()
    {
        // Generate an order summary string
        // (You can implement this method according to your requirements)
        return $"Order ID: {orderId}\nOrder Date: {orderDate}\nTotal Cost: {CalculateTotalCost():C}";
    }

    public string GenerateShippingLabel()
    {
        // Generate a shipping label string
        // (You can implement this method according to your requirements)
        return $"Shipping to:\n{customer.Name}\n{customer.Address.Street}\n{customer.Address.City}, {customer.Address.State} {customer.Address.ZipCode}";
    }
}
