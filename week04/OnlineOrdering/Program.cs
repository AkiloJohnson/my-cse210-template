using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetShippingAddress()
    {
        return address.GetFullAddress();
    }
}

// Product class
class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"Product: {name}, ID: {productId}";
    }
}

// Order class
class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
        {
            label += p.GetPackingLabel() + "\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetShippingAddress()}";
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address addr2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

        // Create customers
        Customer cust1 = new Customer("John Smith", addr1);
        Customer cust2 = new Customer("Jane Doe", addr2);

        // Create orders
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Notebook", "N123", 3.50, 4));
        order1.AddProduct(new Product("Pen", "P456", 1.20, 10));

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Tablet", "T789", 150.00, 1));
        order2.AddProduct(new Product("Charger", "C012", 25.00, 2));
        order2.AddProduct(new Product("Stylus", "S034", 12.99, 1));

        // Display order info
        DisplayOrder(order1);
        Console.WriteLine("\n---------------------------\n");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
    }
}
