public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // initialize the array of size length to store the results
        double[] result = new double[length];

        // loop through the array and calculate the multiples of the number
        // starting from index 0 = number * 1, index 1 = number * 2, index 2 = number * 3, etc.
        for (int i = 0, start = 1; i < length; i++)
        {
            result[i] = number * start;
            start++;
        }
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
        int length = data.Count;
        int[] temp = new int[length];

        // copy the data list to a temporary array
        for (int i = 0; i < length; i++)
        {
            temp[i] = data[i];
        }

        // Rearrange data list from our copy
        // The first index will be the new one based on the rotation
        // Then iterate in a way that within the length but cyclic using modulo
        for (int i = 0; i < length; i++)
        {
            data[i] = temp[(length + i - amount) % length];
        }
    }
}
