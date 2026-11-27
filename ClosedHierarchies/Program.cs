using ClosedHierarchies;

Console.WriteLine("Hello, World!");

Vehicle acar = new Car(200, "Toyota", "Camry", 2020);

switch (acar)
{
    case Car c:
        Console.WriteLine($"Car: {c.Make} {c.Model} {c.Year} with {c.Horsepower} horsepower");
        break;
    case SpeedBoat b:
        Console.WriteLine($"Board: {b.Make} {b.Model} {b.Year} with {b.Horsepower} horsepower");
        break;
}

namespace ClosedHierarchies{
    closed record Vehicle(string Make, string Model, int Year);
    sealed record Car(int Horsepower, string Make, string Model, int Year) : Vehicle(Make, Model, Year);
    sealed record SpeedBoat(int Horsepower, string Make,string Model, int Year): Vehicle(Make, Model, Year);
    public record Boat(int Horsepower, string Make, string Model, int Year);
}
