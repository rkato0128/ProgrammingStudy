using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    // 10773 번 예제 제로

    class Book
    {
        private int[] intArray;
        private int count = 0;

        public Book(int orderCount)
        {
            intArray = new int[orderCount];
        }

        public void AddNum(int num)
        {
            intArray[count] = num;
            count++;
        }

        public void Zero()
        {
            intArray[count - 1] = 0;
            count--;
        }

        public int Sum()
        {
            int result = 0;

            for (int i = count; i > 0; i--)
            {
                result += intArray[i - 1];
            }

            return result;
        }
    }

    class Ex10773
    {
        //static void Main()
        //{
        //    int orderCount = 0;
        //    orderCount = Int32.Parse(Console.ReadLine());

        //    Book myBook = new Book(orderCount);
        //    int order;

        //    for (int i = orderCount; i > 0; i--)
        //    {
        //        order = Int32.Parse(Console.ReadLine());

        //        if (order == 0)
        //        {
        //            myBook.Zero();
        //        }
        //        else
        //        {
        //            myBook.AddNum(order);
        //        }
        //    }

        //    Console.WriteLine(myBook.Sum());
        //}
    }
}
