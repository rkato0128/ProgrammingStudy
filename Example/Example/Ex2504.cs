using System;
using System.Collections;
using System.Collections.Generic;

namespace Example
{
    // 괄호의 값

    class Ex2504
    {
        static void Main()
        {
            string input;
            Stack<char> openedBracket = new Stack<char>();
            Stack<char> closedBracket = new Stack<char>();

            //Stack<char> bracketStack = new Stack<char>();

            char compareChar;
            input = Console.ReadLine();

            foreach (char a in input) // string length 값 받아와서 하는 방식 외에 foreach 로도 되네
            {
                switch (a)
                {
                    case '(':
                    case '[':
                        openedBracket.Push(a);
                        break;
                    case ')':
                    case ']':
                        //closedBracket.Push(a);

                        if (openedBracket.Count != 0)
                        {
                            compareChar = openedBracket.Peek();

                            if (compareChar == a)
                            {

                            }
                        }
                        else
                        {
                            //goto EXIT;
                        }
                        break;
                }
            }

        EXIT:
            Console.WriteLine(0);
        }


    }
}
