using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    class Program
    {
        public static int[,] region;
        public static int m;
        public static int n;
        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());

            region = new int[n, m];

            Thread gardener1 = new Thread(gardenerOne);
            Thread gardener2 = new Thread(gardenerTwo);

            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(region[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
        public static void gardenerOne()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (region[i, j] == 0)
                        region[i, j] = 1;
                    Thread.Sleep(100);
                }
            }
        }

        public static void gardenerTwo()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (region[j, i] == 0)
                        region[j, i] = 2;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
