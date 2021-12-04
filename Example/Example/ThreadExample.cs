using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    class ThreadExample
    {
        static int temp = 0;

        static void Main()
        {
            Thread t1 = new Thread(AddNum);
            Thread t2 = new Thread(AddNum);
            Thread t3 = new Thread(AddNum);

            t1.Start();
            t2.Start();
            t3.Start();
        }

        static void AddNum()
        {
            temp++;
            Console.WriteLine(temp);
        }
    }
}
