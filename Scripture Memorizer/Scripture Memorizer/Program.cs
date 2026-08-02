string filePath = Path.Combine(AppContext.BaseDirectory, "scriptures.txt");

// If not found in the executable folder, also check the project folder
if (!File.Exists(filePath))
{
    filePath = Path.Combine(Directory.GetCurrentDirectory(), "scriptures.txt");
}

if (!File.Exists(filePath))
{
    Console.WriteLine("Error: scriptures.txt not found.");
    Console.WriteLine($"Looked in: {AppContext.BaseDirectory}");
    Console.WriteLine($"And: {Directory.GetCurrentDirectory()}");
    return;
}