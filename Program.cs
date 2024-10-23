using System;
using System.Collections.Generic;

namespace ConsoleApp1;
public class Program
{
    static List<Customer> customers;
    static List<Table> tables;
    static List<Staff> staffs;
    static Menu menu = Menu.Instance;
    static void Main()
    {

        LoadData();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nRestaurant Management System");
            Console.WriteLine("1. Book a table");
            Console.WriteLine("2. Show bookings");
            Console.WriteLine("3. Place an order");
            Console.WriteLine("4. Prepare dishes");
            Console.WriteLine("5. Serve dishes");
            Console.WriteLine("6. Show orders");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter your phone number: ");
                    string phone = Console.ReadLine();

                    Customer customer = new Customer(customers.Count + 1, name, email, phone);
                    customers.Add(customer);

                    Console.WriteLine("Choose a table to book:");
                    for (int i = 0; i < tables.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Table {tables[i].Number} - {tables[i].Seats} seats - {tables[i].Status}");
                    }
                    Console.Write("Enter the number of the table: ");
                    int tableIndex = int.Parse(Console.ReadLine()) - 1;

                    if (tableIndex >= 0 && tableIndex < tables.Count)
                    {
                        tables[tableIndex].BookTable(customer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Booking list:");
                    foreach (var table in tables)
                    {
                        if (table.Status == "Booked")
                        {
                            Console.WriteLine($"Table {table.Number} - {table.Seats} seats - {table.Status}");
                        }
                    }
                    break;

                case "3":
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("No customers available.");
                        break;
                    }

                    Console.WriteLine("Choose a customer to place an order:");
                    for (int i = 0; i < customers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {customers[i].Name}");
                    }
                    Console.Write("Enter the number of the customer: ");
                    int customerIndex = int.Parse(Console.ReadLine()) - 1;

                    if (customerIndex >= 0 && customerIndex < customers.Count)
                    {
                        Customer selectedCustomer = customers[customerIndex];
                        Order newOrder = new Order(selectedCustomer.Orders.Count + 1);

                        bool ordering = true;
                        while (ordering)
                        {
                            menu.DisplayMenu();
                            Console.Write("Enter the number of the item to add to the order (or type 'done' to finish): ");
                            string input = Console.ReadLine();

                            if (input.ToLower() == "done")
                            {
                                ordering = false;
                                selectedCustomer.AddOrder(newOrder);
                            }
                            else
                            {
                                int itemIndex = int.Parse(input) - 1;
                                if (itemIndex >= 0 && itemIndex < menu.Items.Count)
                                {
                                    newOrder.AddItem(menu.Items[itemIndex]);
                                    Console.WriteLine($"{menu.Items[itemIndex].Name} has been added to the order.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                    break;

                case "4":
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("No customers available.");
                        break;
                    }
                    foreach (var customer1 in customers)
                    {
                        foreach (var order in customer1.Orders)
                        {
                            if (order.Status == "Pending")
                            {
                                staffs[0].CookOrder(order); // Assuming the first staff cooks the order
                                order.UpdateStatus("Cooking");
                            }
                        }
                    }
                    Console.WriteLine("All dishes have been prepared.");

                    break;

                case "5":
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("No customers available.");
                        break;
                    }

                    foreach (var customer1 in customers)
                    {
                        foreach (var order in customer1.Orders)
                        {
                            if (order.Status == "Cooking")
                            {
                                staffs[0].ServeOrder(order); // Assuming the first staff serves the order
                                order.UpdateStatus("Served");
                            }
                        }
                    }
                    Console.WriteLine("All dishes have been served.");
                    break;

                case "6":
                    Console.WriteLine("Order list:");
                    foreach (var cust in customers)
                    {
                        cust.DisplayInfo();
                    }
                    break;
                case "7":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void LoadData()
    {
        customers = new List<Customer>();
        tables = new List<Table>();
        staffs = new List<Staff>();
        // Menu menu = Menu.Instance;

        menu.AddItem(new BeefsteakF());
        menu.AddItem(new NoodleF());
        menu.AddItem(new SaladF());
        menu.AddItem(new CocktailF());

        tables.Add(new Table(1, 6, "Available"));
        tables.Add(new Table(2, 6, "Available"));
        tables.Add(new Table(3, 6, "Available"));

        staffs.Add(new Staff(1, "John", "John@gmail.com", "+21424214", "Casual"));
        staffs.Add(new Staff(2, "Huy", "Huy@gmail.com", "+49588223", "Master Chef"));
    }
}
