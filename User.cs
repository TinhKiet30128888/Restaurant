namespace ConsoleApp1;
public abstract class User
{
    // Encapsulation dữ liệu của đối tượng an toàn khỏi sự truy cập và thay đổi từ bên ngoài
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }
    // protected, cho thay đổi ở trong lớp person hoặc lớp được kế thừa lớp person

    public User(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone number: {Phone}");
    }
    // Polymorphism

}