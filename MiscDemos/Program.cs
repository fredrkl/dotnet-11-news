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

Console.WriteLine($"Unique car models (case-insensitive): {models.Count}");

// Labeled break and continue
search: foreach (var model in models)
{
    // Pretend we are going through a second large list for each model and we want to break out of the outer loop if we find a match.
    if(model.StartsWith("C", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Found a model starting with 'C': {model}");
        break search; // Labeled break
    }
}
