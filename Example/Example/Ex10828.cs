using System;
using System.Collections;

namespace Example
{
    // 스택 자료구조

    class MyStack
    {
        private int[] stackArray;
        private int count = 0;

        public MyStack() // 생성자에 public 붙여야됨
        {
            stackArray = new int[10000];
        }

        public void Push(int x)
        {
            stackArray[count] = x;
            count++;
        }

        public void Pop()
        {
            if (count != 0)
            {
                Console.WriteLine(stackArray[count-1]);
                stackArray[count-1] = 0;
                count--;
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        public void Size()
        {
            Console.WriteLine(count);
        }

        public void Empty()
        {
            if (count == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        public void Top()
        {
            if (count != 0)
            {
                Console.WriteLine(stackArray[count - 1]);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }

    class Ex10828
    {
        //static void Main()
        //{
        //    MyStack myStack = new MyStack();

        //    int inputCount;
        //    string input;
        //    string[] inputText;
        //    char space = ' ';

        //    inputCount = Int32.Parse(Console.ReadLine());

        //    for(int i = inputCount; i > 0; i--)
        //    {
        //        input = Console.ReadLine();
        //        inputText = input.Split(space);

        //        switch (inputText[0])
        //        {
        //            case "push":
        //                myStack.Push(Int32.Parse(inputText[1]));
        //                break;
        //            case "pop":
        //                myStack.Pop();
        //                break;
        //            case "size":
        //                myStack.Size();
        //                break;
        //            case "empty":
        //                myStack.Empty();
        //                break;
        //            case "top":
        //                myStack.Top();
        //                break;
        //        }
        //    }
        //}

    }
}
