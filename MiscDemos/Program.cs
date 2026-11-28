Console.WriteLine("Hello, World!");

// Showcasing the new HashSet<T> constructor that takes a comparer as an argument.
HashSet<string> models = [
    with(StringComparer.OrdinalIgnoreCase),
    "Toyota Camry",
    "Camry",
    "Honda Accord",
    "Ford Mustang",
    "CAMRY",
    "Chevrolet Camaro"
];

List<string> randomstrings = [
    "Orange",
    "Apple",
    "Banana",
    "Grape",
    "Mango"
];

Console.WriteLine($"Unique car models (case-insensitive): {models.Count}");

// Labeled break and continue
search: foreach (var model in models)
{
    foreach (var randomstring in randomstrings)
    {
        if (randomstring.Equals("Banana", StringComparison.OrdinalIgnoreCase))
        {
            break search; // Labeled break to exit the outer loop
        }
    }
}
