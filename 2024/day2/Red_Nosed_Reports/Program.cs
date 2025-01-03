// Get memory usage before
long memoryBefore = GC.GetTotalMemory(true);

// Step 1: Read the input from the text file
string filePath = "Input.txt";
int safeRowCount = 0;

using (StreamReader reader = new(filePath))
{
    string? line;

    while ((line = await reader.ReadLineAsync()) != null)
    {
        // Step 2: Process each row to determine if it's "safe" or "unsafe"
        int[] numbers = [.. line.Split(' ').Select(int.Parse)];
        if (IsRowSafe(numbers))
        {
            safeRowCount++;
        }
    }
}

Console.WriteLine(safeRowCount);

// Get memory usage after
long memoryAfter = GC.GetTotalMemory(true);

// Calculate and display memory usage
long memoryUsed = memoryAfter - memoryBefore;
Console.WriteLine($"Memory Before: {memoryBefore / 1024.0:F2} KB");
Console.WriteLine($"Memory After: {memoryAfter / 1024.0:F2} KB");
Console.WriteLine($"Memory Used: {memoryUsed / 1024.0:F2} KB");

static bool IsRowSafe(int[] numbers)
{
    string? trend = null; // "increasing" or "decreasing"

    for (int i = 1; i < numbers.Length; i++)
    {
        int difference = numbers[i] - numbers[i - 1];

        // Determine the trend at the second element
        if (i == 1)
        {
            trend = difference > 0 ? "increasing" : (difference < 0 ? "decreasing" : null);
        }

        // Check if trend changes
        if (trend != null && ((difference > 0 && trend == "decreasing") || (difference < 0 && trend == "increasing")))
        {
            return false;
        }

        // Check if the row is "unsafe"
        if (Math.Abs(difference) > 3 || difference == 0)
        {
            return false;
        }
    }

    return true; // Row is "safe"
}

