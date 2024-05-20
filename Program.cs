using System;
using System.Collections.Generic;

class Computer
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }

    public Computer(int id, string brand, string model, double price)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Price = price;
    }
}

class Shop
{
    private List<Computer> inventory = new List<Computer>();
    private int nextId = 1;

    public void AddComputer(string brand, string model, double price)
    {
        Computer newComputer = new Computer(nextId, brand, model, price);
        inventory.Add(newComputer);
        Console.WriteLine($"Computer added with ID: {nextId}");
        nextId++;
    }

    public void DisplayInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No computers in inventory.");
            return;
        }
        Console.WriteLine("Inventory: ");
        foreach (var computer in inventory)
        {
            Console.WriteLine($"ID: {computer.Id}, Brand: {computer.Brand}, Model: {computer.Model}, Price: ${computer.Price}");
        }
    }

    public void SellComputer(int id)
    {
        Computer computerToSell = inventory.Find(c => c.Id == id);
        if (computerToSell != null)
        {
            inventory.Remove(computerToSell);
            Console.WriteLine($"Selling Computer: {computerToSell.Brand} {computerToSell.Model} for ${computerToSell.Price}");
        }
        else
        {
            Console.WriteLine($"Computer with ID {id} not found.");
        }
    }
}

class Program
{
    static void ShowMenu()
    {
        Console.WriteLine("Computer Shop Management System");
        Console.WriteLine("1. Add a new computer to the inventory");
        Console.WriteLine("2. Display inventory");
        Console.WriteLine("3. Sell a computer");
        Console.WriteLine("4. Exit");
    }

    static void Main()
    {
        Shop shop = new Shop();
        int choice;

        while (true)
        {
            ShowMenu();
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter brand: ");
                    string brand = Console.ReadLine();
                    Console.Write("Enter model: ");
                    string model = Console.ReadLine();
                    Console.Write("Enter price: ");
                    double price = double.Parse(Console.ReadLine());
                    shop.AddComputer(brand, model, price);
                    break;
                case 2:
                    shop.DisplayInventory();
                    break;
                case 3:
                    Console.Write("Enter ID of computer to sell: ");
                    int id = int.Parse(Console.ReadLine());
                    shop.SellComputer(id);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

