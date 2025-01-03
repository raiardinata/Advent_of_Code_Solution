Input.txt serve as the input from Advent of Code website. The input is as is from the website without editting.

For this puzzle approach I use StreamReader to read the input file then iterate it asynchronously.

Bind it into int[] array then process it into IsRowSafe function for better readabillity.

There will be two validation based on the case of day 2:
1. The trend cannot be different for the entire row. Either it keeps increasing or keep decreasing.
2. The difference between element must be between 1 to 3 at most.

There will be three steps of validation to acomplished that rule.
1. Determine the trend at teh second element.
2. Check if trend changes.
3. Check if the row is unsafe.

Then calculate the rest.
