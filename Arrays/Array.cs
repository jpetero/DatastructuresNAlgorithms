namespace DataStructures.Arrays
{
    class Array
    {
        public static int[] Reverse(int[] array)
        {
            int j = 0;
            for (int i = array.Length - 1; i > array.Length / 2; i--)
            {
                int last = array[i];
                array[i] = array[j];
                array[j] = last;
                j++;
            }
            return array;
        }
    }
}
