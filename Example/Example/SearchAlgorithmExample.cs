using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class SearchAlgorithmExample
    {
        static int[] array = new int[] {1, 6, 8, 13, 20};
        static int time = 0;

        static void Main()
        {
            Console.WriteLine(BinarySearch(array, 0, array.Length - 1, 20));
            Console.WriteLine(time);

        }

        static int BinarySearch(int[] array, int start, int end, int target)
        {
            time++;

            int half = (end - start) / 2;

            if (array[start + half] == target)
            {
                return start + half;
            }
            else if (array[start + half] > target)
            {
                return BinarySearch(array, start, start + half - 1, target);
            }
            else if (array[start + half] < target)
            {
                return BinarySearch(array, start + half + 1, end, target);
            }

            return 0;
        }
    }
}
