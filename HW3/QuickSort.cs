namespace HW3
{
    public static class QuickSort
    {
        public static void Sort(Vector vector, int startIndex, int excludedEndIndex)
        {
            if (excludedEndIndex-startIndex<2) return;
            int central = Divide(vector, startIndex, excludedEndIndex);
            Sort(vector, startIndex, central);
            Sort(vector, central+1, excludedEndIndex);
        }

        private static int Divide(Vector vector, int startIndex, int excludedEndIndex)
        {
            int central = vector[excludedEndIndex-1];
            int firstBiggerIndex = startIndex;
            
            for (int j = startIndex; j < excludedEndIndex-1; j++) {
                if (vector[j] <= central) {
                    (vector[firstBiggerIndex], vector[j]) = (vector[j], vector[firstBiggerIndex]);
                    firstBiggerIndex++;
                }
            }

            (vector[firstBiggerIndex], vector[excludedEndIndex-1]) = (vector[excludedEndIndex-1], vector[firstBiggerIndex]);
            return firstBiggerIndex;
        }
    }
}