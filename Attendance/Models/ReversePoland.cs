using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Attendance.Models
{
    public static class CalculateReversePolish
    {
        public static BigInteger Calculate(this Queue<BigInteger> integers)
        {
            var calcStack = new Stack<BigInteger>();
            foreach (var elem in integers)
            {
                var token = elem.ToCalculatorType();
                if (token == CalculatorType.Unknown)
                {
                    calcStack.Push(elem);
                }
                else
                {
                    var left = calcStack.Pop();
                    var right = calcStack.Pop();
                    BigInteger res;

                    switch (token)
                    {
                        case CalculatorType.Mul:
                            res = left * right;
                            calcStack.Push(res);
                            break;
                        case CalculatorType.Div:
                            res = right / left;
                            calcStack.Push(res);
                            break;
                        case CalculatorType.Plus:
                            res = left + right;
                            calcStack.Push(res);
                            break;
                        case CalculatorType.Minus:
                            res = right - left;
                            calcStack.Push(res);
                            break;
                    }
                }
            }

            return calcStack.Pop();
        }
    }

    public static class ReversePolish
    {
        public static Queue<BigInteger> ConvertReversePolish(this ICollection<BigInteger> list)
        {
            var opStack = new Stack<CalculatorType>();
            var queue = new Queue<BigInteger>();
            foreach (BigInteger integer in list)
            {
                var token = integer.ToCalculatorType();
                if (token == CalculatorType.Unknown)
                {
                    queue.Enqueue(integer);
                }
                else
                {
                    while (opStack.Count > 0 && Priority(opStack.Peek()) >= Priority(token))
                    {
                        queue.Enqueue((int)opStack.Pop());
                    }
                    opStack.Push(token);
                }
            }

            while (opStack.Count > 0)
            {
                queue.Enqueue((int)opStack.Pop());
            }

            return queue;
        }


        public static int Priority(CalculatorType c)
        {
            if (c == CalculatorType.Mul || c == CalculatorType.Div)
            {
                return 2;
            }
            else if (c == CalculatorType.Plus || c == CalculatorType.Minus)
            {
                return 1;
            }
            return 0;
        }

        public static bool isOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static string Test(string text)
        //{
        //    string infix = text;
        //    string[] tokens = infix.Split(' ');

        //    Stack<string> s = new Stack<string>();
        //    var sb = new StringBuilder();
        //    foreach (string c in tokens)
        //    {
        //        if (int.TryParse(c, out int n))
        //        {
        //            sb.Append(c);
        //        }
        //        if (c == "(")
        //        {
        //            s.Push(c);
        //        }
        //        if (c == ")")
        //        {
        //            while (s.Count != 0 && s.Peek() != "(")
        //            {
        //                sb.Append(s.Pop());
        //            }
        //            s.Pop();
        //        }
        //        if (isOperator(c) == true)
        //        {
        //            while (s.Count != 0 && Priority(s.Peek()) >= Priority(c))
        //            {
        //                sb.Append(s.Pop());
        //            }
        //            s.Push(c);
        //        }
        //    }

        //    while (s.Count != 0)//if any operators remain in the stack, pop all & add to output list until stack is empty 
        //    {
        //        sb.Append(s.Pop());
        //    }

        //    return sb.ToString();
        //}

        //public static int Priority(string c)
        //{
        //    if (c == "^")
        //    {
        //        return 3;
        //    }
        //    else if (c == "*" || c == "/")
        //    {
        //        return 2;
        //    }
        //    else if (c == "+" || c == "-")
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        //public static bool isOperator(string c)
        //{
        //    if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
