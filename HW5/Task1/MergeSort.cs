namespace HW5.Task1
{
    public class MergeSort
    {
        public static int[] Sort(int[] source)
        {
            if (source.Length<2) return source;
            int n = source.Length / 2;
            return Merge(Sort(source[..n]), Sort(source[n..]));
        }

        private static int[] Merge(int[] part1, int[] part2)
        {
            int i = 0, j = 0;
            int[] result = new int[part1.Length + part2.Length];
            while (i < part1.Length && j < part2.Length)
            {
                if (part1[i] <= part2[j])
                {
                    result[i + j] = part1[i];
                    i++;
                }
                else
                {
                    result[i + j] = part2[j];
                    j++;
                }
            }
// Тут таки оптимальніше for!
            while (i < part1.Length)
            {
                result[i + j] = part1[i];
                i++;
            }
            
            while (j < part2.Length)
            {
                result[i + j] = part2[j];
                j++;
            }

            return result;
        }
    }
}
