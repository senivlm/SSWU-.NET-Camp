namespace HW3
{
    public static class QuickSort
    {
        public static void Sort(Vector vector, int startIndex, int excludedEndIndex)
        {
            if (excludedEndIndex-startIndex<2) return;
            int central = DivideS(vector, startIndex, excludedEndIndex);
            Sort(vector, startIndex, central);
            Sort(vector, central+1, excludedEndIndex);
        }

        private static int DivideE(Vector vector, int startIndex, int excludedEndIndex)
        {
            int central = vector[excludedEndIndex-1];
            int firstBiggerIndex = startIndex;
            
            for (int i = startIndex; i < excludedEndIndex-1; i++) {
                if (vector[i] <= central) {
                    (vector[firstBiggerIndex], vector[i]) = (vector[i], vector[firstBiggerIndex]);
                    firstBiggerIndex++;
                }
            }

            (vector[firstBiggerIndex], vector[excludedEndIndex-1]) = (vector[excludedEndIndex-1], vector[firstBiggerIndex]);
            return firstBiggerIndex;
        }
        
        private static int DivideS(Vector vector, int startIndex, int excludedEndIndex)
        {
            int central = vector[startIndex];
            int lastSmallerIndex = excludedEndIndex-1;
            
            for (int i = excludedEndIndex-1; i > startIndex; i--) {
                if (vector[i] >= central) {
                    (vector[lastSmallerIndex], vector[i]) = (vector[i], vector[lastSmallerIndex]);
                    lastSmallerIndex--;
                }
            }

            (vector[lastSmallerIndex], vector[startIndex]) = (vector[startIndex], vector[lastSmallerIndex]);
            return lastSmallerIndex;
        }
    }
}