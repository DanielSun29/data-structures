using System;
using System.Net.Http.Headers;

namespace RecursionPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Divide(12,3)}");
        }
        static int Multiply(int x, int y)
        {
            int ans = 0;

            if (y < 0)
            {
                return Multiply(-x, -y);
            }

            if (y < 1)
            {
                return ans;
            }

            ans = x + Multiply(x, y - 1);
            return ans;
        }
        static int Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new ArgumentException("divided by 0");
            }

            int ans = 0;

            if (x <= 0)
            {
                return ans;
            }

            ans = 1 + Divide(x - y, y);
            return ans;
        }
    }
}