namespace PrimeFind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = 1_000_000;
            PrimeCalcSieve(max);
        }

        static void PrimeCalcSieve(int max)
        {
            int count = 0;
            bool[] isPrime = new bool[max + 1];
            for (int i = 2; i <= max; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= max; i++)
            {
                if (!isPrime[i]) continue;

                for (int j = i * i; j <= max; j += i)
                {
                    isPrime[j] = false;
                }
            }

            for (int i = 2; i <= max; i++)
            {
                if (!isPrime[i]) continue;

                Console.WriteLine(i);
                count++;
            }
            Console.WriteLine("Count: " + count);
        }

        static void PrimeCalcBad(int max)
        {
            int count = 0;
            bool[] isPrime = new bool[max + 1];
            for (int i = 2; i < max; i++)
            {
                isPrime[i] = true;
            }
            for (int i = 2; i <= max; i++)
            {
                for (int j = 2; j <= (int)Math.Sqrt(i); j++)
                {
                    if (i % j != 0) continue;
                    isPrime[i] = false;
                    break;
                }
            }

            for (int i = 2; i < max; i++)
            {
                if (!isPrime[i]) continue;

                Console.WriteLine(i);
                count++;
            }
            Console.WriteLine("Count: " + count);
        }
    }
}
