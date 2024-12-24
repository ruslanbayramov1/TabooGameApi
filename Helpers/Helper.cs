namespace TabooGameApi.Helpers;

public static class Helper
{
    public static int[] GetRandomUniqueValues(int[] array, int count)
    {
        Random random = new Random();

        if (count > array.Length)
            throw new ArgumentException("The count cannot be greater than the number of elements in the array.");

        var shuffledArray = array.OrderBy(x => random.Next()).ToArray();
        return shuffledArray.Take(count).ToArray();
    }
}
