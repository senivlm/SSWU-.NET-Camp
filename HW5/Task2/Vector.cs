using System;

namespace HW3
{
    public class Vector
    {
        int[] arr;
        public int Length { get; private set; }
        private int capacity;

        #region PreviousHomeTasks
        public int this[int index]
        {
            get
            { 
                if(index >= 0 && index < Length) return arr[index];
                if (index < 0 && index >= -Length) return arr[Length + index];
                throw new Exception("Index out of range array");
                }
            set 
            {
                if (index>=capacity) Resize(index+1);
                if (index >= 0 && index < Length)
                {
                    arr[index] = value;
                    Length = Math.Max(Length, index + 1);
                }
                else if (index < 0 && index >= -Length)
                {
                    arr[Length + index] = value;
                }
                else throw new Exception("Index out of range array");
            }
        }

        public Vector(int[] sourceArray)
        {
            arr = new int[sourceArray.Length];
            for (int i = 0; i < sourceArray.Length; i++)
            {
                arr[i] = sourceArray[i];
            }
            Length = arr.Length;
            capacity = arr.Length;
        }
        
        public Vector(int n)
        {
            arr = new int[n];
            Length = n;
            capacity = n;
        }

        private void Resize(int newCapacity)
        {
            int[] newArr = new int[newCapacity];
            for (int i = 0; i < Math.Min(Length, newCapacity); i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
            capacity = newCapacity;
            Length = (Length < newCapacity ? Length : newCapacity);
            if (Length > newCapacity)
            {
                Length = newCapacity;
            }
        }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()
        {
            //int index = Array.IndexOf(arr, 2);
            //Console.WriteLine(index);

            Random random = new Random();
            int x;
            for (int i = 0; i < Length; i++)
            {
                while(arr[i] == 0)
                {
                    x = random.Next(1, arr.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == arr[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        arr[i] = x;
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }

        public void Push(int value)
        {
            if (Length==capacity) Resize(capacity+5);
            arr[Length] = value;
            Length++;
        }

        public int Pop()
        {
            if (Length < 1) throw new Exception("Vector is empty!");
            Length--;
            return arr[Length];
        }

        
        public bool IsPalindrome()
        {
            for (int i = 0; i < Length / 2 + 1; i++)
            {
                if (arr[i] != arr[^(1 + i)]) return false;
            }
            return true;
        }
        
        public void Reverse()
        {
            int[] newArr = new int[capacity];
            for (int i = 0; i < Length; i++)
            {
                newArr[i] = arr[Length - 1 - i];
            }

            arr = newArr;
        }

        public int GetMaxSubsequenceIndex()
        {
            int sequenceCounter = 0;
            int maxSequenceIndex = 0;
            int maxSequenceCounter = 0;
            int currentSequenceValue = int.MaxValue;
            int currentSequenceIndex = 0;

            for (int i = 0; i < Length; i++)
            {
                if (arr[i] == currentSequenceValue)
                {
                    sequenceCounter++;
                    if (sequenceCounter > maxSequenceCounter)
                    {
                        maxSequenceCounter = sequenceCounter;
                        maxSequenceIndex = currentSequenceIndex;
                    }
                }
                else
                {
                    sequenceCounter = 1;
                    currentSequenceValue = arr[i];
                    currentSequenceIndex = i;
                }
            }

            return maxSequenceIndex;
        }

        public int PopByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                int value = arr[index];
                for (int i = index; i < Length - 1; i++) arr[i] = arr[i + 1];
                Length--;
                return value;
            }
            throw new Exception("Index out of range array");
        }

        public void Shuffle()
        {
            Vector initValues = new Vector(arr);
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                arr[i] = initValues.PopByIndex(random.Next(Length - i));
            }
        }
        #endregion
        
        
    }
}
