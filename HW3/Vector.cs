using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        int[] arr;
        public int Length { get; private set; }
        private int capacity;

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

                if (index < 0 && index >= -Length)
                {
                    arr[Length + index] = value;
                }
                throw new Exception("Index out of range array");
            }
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
            Length = arr.Length;
            capacity = arr.Length;
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

        public Vector(int n)
        {
            arr = new int[n];
            Length = n;
            capacity = n;
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

        public Pair[] CalculateFreq()
        {
            
            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0,0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if(arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
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
        
        
    }
}
