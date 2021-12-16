using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class SortingAlgorithmExample
    {
        static int[] unsortedArray = new int[] {1,4,3,2};

        static void Main()
        {
            //SelectionSort(unsortedArray);
            MergeSort(unsortedArray, 0, unsortedArray.Length - 1);

            for(int i = 0; i < unsortedArray.Length; i++)
                Console.Write(unsortedArray[i] + " ");
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int  j = i+1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];

                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static int count = 0;

        static void MergeSort(int[] array, int startIndex, int endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            // 분할할 중간지점 : start + (end - start) / 2 = start + end/2 - start/2 = start/2 + end/2

            if (startIndex < endIndex)
            {
                count++;
                Console.WriteLine(count);

                MergeSort(array, startIndex, midIndex);
                MergeSort(array, midIndex + 1, endIndex);

                Merge();
            }
        }

        static void Merge()
        { 
            // 분할한 배열 1, 2 생성 및 배열에 값 넣기

            // 배열 1, 2 비교하기

            // 비교한 정렬된 값 원본 배열에 삽입
        }
    }
}
