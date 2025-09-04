public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int i = 0; // pointer for list1
        int j = 0; // pointer for list2
        int[] result = new int[select.Length];

        for (int k = 0; k < select.Length; k++)
        {
            if (select[k] == 1)
            {
                result[k] = list1[i];
                i++;
            }
            else if (select[k] == 2)
            {
                result[k] = list2[j];
                j++;
            }
            else
            {
                throw new ArgumentException("Selector must contain only 1 or 2.");
            }
        }

        return result; // ✅ FIXED
    }
}