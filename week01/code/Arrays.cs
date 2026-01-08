public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {       // STEP 1: Understand the problem
    // We need to return an array of size 'length'
    // Each element should be a multiple of 'number'
    // The first value is number * 1, the second is number * 2, etc.

    // STEP 2: Create an array to store the result
    // The size of the array must match 'length'
    double[] result = new double[length];

    // STEP 3: Loop through the array indices
    // Arrays start at index 0, so we use i from 0 to length - 1
    for (int i = 0; i < length; i++)
    {
        // STEP 4: Calculate each multiple
        // (i + 1) ensures the first value is number * 1
        result[i] = number * (i + 1);
    }

    // STEP 5: Return the completed array
    return result;

        
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
           // STEP 1: Create a new list to store rotated values
    List<int> rotated = new List<int>(data.Count);

    // STEP 2: Initialize the list with placeholder values
    for (int i = 0; i < data.Count; i++)
        rotated.Add(0);

    // STEP 3: Move each element to its new position
    // New index = (current index + amount) % data.Count
    for (int i = 0; i < data.Count; i++)
    {
        int newIndex = (i + amount) % data.Count;
        rotated[newIndex] = data[i];
    }

    // STEP 4: Copy values back into the original list
    for (int i = 0; i < data.Count; i++)
    {
        data[i] = rotated[i];
    }
    }
}
