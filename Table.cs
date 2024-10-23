namespace ConsoleApp1;
public class Table
{
    public int Number { get; private set; }
    public int Seats { get; private set; }
    public string Status { get; private set; }

    public Customer Customer { get; private set; }

    public Table(int number, int seats, string status)
    {
        Number = number;
        Seats = seats;
        Status = status;
    }


    public void BookTable(User customer)
    {
        Customer = (Customer)customer;
        Status = "Booked";
        Console.WriteLine($"Customer{customer.Name} has reserved table {Number}.");
    }
}