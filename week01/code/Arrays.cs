public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
    /// 
    /// Create an array and then loop through a range of the length
    /// each time I loop I will add the multiple to the index of the array
    public static double[] MultiplesOf(double number, int length)
    {
        double[] ListofMultiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            ListofMultiples[i] = number * (i + 1);
        }

        return ListofMultiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    /// I created 2 empty lists and I put the 2 different pieces of the list split by the amount
    /// Then I cleared the original list and added the 2 pieces to appear rotated to the right. 
    public static void RotateListRight(List<int> data, int amount)
    {
        int split = data.Count - amount;

        List<int> modifList1 = new List<int>();
        List<int> modifList2 = new List<int>();

        modifList1.AddRange(data.GetRange(split, amount));
        modifList2.AddRange(data.GetRange(0, split));

        data.Clear();
        data.AddRange(modifList1);
        data.AddRange(modifList2);
    }
}
