The problem :
There is unusual data (your puzzle input) consists of many reports, one report per line. Each report is a list of numbers called **levels** that are separated by spaces. For example:

7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9

Each levels have to be counted as a safe level or unsafe level by following certain rule as:
  a. The levels are either all increasing or all decreasing.
  b. Any two adjacent levels differ by at least one and at most three.
Analyze the unusual data from the engineers. How many reports are safe?

Solution:
1. Input.txt serve as the input from Advent of Code website. The input is as is from the website without editting.
2. For this puzzle approach I use StreamReader to read the input file then iterate it asynchronously(for memory consumption efficiency).
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
4. Bind it into int[] array then process it into IsRowSafe function for better readabillity.
  if (IsRowSafe(numbers))
  {
      safeRowCount++;
  }
  static bool IsRowSafe(int[] numbers)
  {
      ... the rest of the code
  }
6. There will be two validation based on the case of day 2:
   a. The trend cannot be different for the entire row. Either it keeps increasing or keep decreasing.
   b. The difference between element must be between 1 to 3 at most.
  And there will be three steps of validation to acomplished that rule.
  1. Determine the trend increasing or decreasing at the second element.
    if (i == 1) // i is the index of the array
    {
      trend = difference > 0 ? "increasing" : (difference < 0 ? "decreasing" : null); // use ternerarry to decide the trend
    }
  3. Check if trend changes.
    if (trend != null && ((difference > 0 && trend == "decreasing") || (difference < 0 && trend == "increasing")))
    {
        return false;
    }
  5. Check if the row is unsafe.
    if (Math.Abs(difference) > 3 || difference == 0) // to accomplish the two validation The trend cannot be different for the entire row. Either it keeps increasing or keep decreasing. And the difference between element must be between 1 to 3 at most.
    {
        return false;
    }

Then calculate the rest.
