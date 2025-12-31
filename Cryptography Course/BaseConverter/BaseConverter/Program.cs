using System.Text;

namespace BaseConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("From:");
                string? fromInput = Console.ReadLine();
                int from = 0;
                if (int.TryParse(fromInput, out int result))
                {
                    from = result;
                }

                Console.WriteLine("Num1:");
                string? numInput = Console.ReadLine();

                Console.WriteLine("To:");
                string? toInput = Console.ReadLine();
                int to = 0;
                if (int.TryParse(toInput, out int result2))
                {
                    to = result2;
                }

                string output = BaseConvert(from, to, numInput);

                Console.WriteLine($"Result: {output}");
            }
        }

        static string BaseConvert(int from, int to, string value)
        {
            int intValue = 0;
            // Convert to base 10
            if (from == 10)
            {
                intValue = int.Parse(value);
            }
            else
            {
                char[] values = value.ToCharArray();
                int[] intValues = new int[values.Length];
                if (from < 37)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        if ('0' <= values[i] && values[i] <= '9')
                        {
                            intValues[i] = values[i] - '0';
                        }
                        else
                        {
                            intValues[i] = values[i] - 'A' + 10;
                        }
                    }
                }
                else if (from < 65)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        if ('A' <= values[i] && values[i] <= 'Z')
                        {
                            intValues[i] = values[i] - 'A';
                        }
                        else if ('a' <= values[i] && values[i] <= 'z')
                        {
                            intValues[i] = values[i] - 'a' + 26;
                        }
                        else if ('0' <= values[i] && values[i] <= '9')
                        {
                            intValues[i] = values[i] - '0' + 52;
                        }
                        else if (values[i] == '+')
                        {
                            intValues[i] = 62;
                        }
                        else if (values[i] == '/')
                        {
                            intValues[i] = 63;
                        }
                        else
                        {
                            Console.WriteLine($"The {i}th index is not a valid inpu");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("from is larger than base 64");
                }
                for (int i = 0; i < intValues.Length; i++)
                {
                    intValue += intValues[intValues.Length - 1 - i] * (int)Math.Pow(from, i);
                }
            }

            // Convert to "to" base
            List<int> rems = new();
            while (intValue != 0)
            {
                rems.Add(intValue % to);
                intValue /= to;
            }

            StringBuilder output = new();

            if (to < 37)
            {
                for (int i = rems.Count - 1; i >= 0; i--)
                {
                    if (rems[i] < 10)
                    {
                        output.Append(rems[i]);
                    }
                    else
                    {
                        string s = (rems[i] - 10 + 'A').ToString();
                        output.Append(s);
                    }
                }
            }
            else
            {
                for (int i = rems.Count - 1; i >= 0; i--)
                {
                    if (rems[i] < 26)
                    {
                        char c = (char)(rems[i] + 'A');
                        output.Append(c);
                    }
                    else if (25 < rems[i] && rems[i] <  52)
                    {
                        char c = (char)(rems[i] - 26 + 'a');
                        output.Append(c);
                    }
                    else if (51 < rems[i] && rems[i] < 62)
                    {
                        string s = (rems[i] - 52).ToString();
                        output.Append(s);
                    }
                    else if (rems[i] == 62)
                    {
                        output.Append('+');
                    }
                    else if (rems[i] == 63)
                    {
                        output.Append('/');
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }

            return output.ToString();
        }

        int gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        bool isCoPrime(int a, int b)
        {
            if (gcd(a, b) == 1)
            {
                return true;
            }
            return false;
        }

        void SpecialIfStatement(int a)
        {
            int b = a == 42 ? 17 : 0;
            // These 2 are equal
            if (a == 42)
            {
                b = 17;
            }
            else
            {
                b = 0;
            }
        }
    }
}
