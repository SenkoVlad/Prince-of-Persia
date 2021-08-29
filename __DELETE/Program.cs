using System;
using System.Collections.Generic;
using System.IO;

namespace __DELETE
{
    class Program
    {
        public struct hob
        {
            public int n { get; set; }
            public int m { get; set; }
            public int k { get; set; }
            public int step { get; set; }
        }

        static void Main(string[] args)
        {
            hob d = new hob();
            hob d1 = new hob();
            Queue<hob> mq = new Queue<hob>();

            int n, m, k;
            int[,,] lab = new int[3, 3, 3];

            using (StreamReader reader = new StreamReader("input.txt"))
            {
                string[] firstLineElements = reader.ReadLine().Split(' ');
                n = int.Parse(firstLineElements[0]);
                m = int.Parse(firstLineElements[1]);
                k = int.Parse(firstLineElements[2]);

                char item;

                for (int z = 0; z < n; z++)
                    for (int x = 0; x < m; x++)
                        for (int c = 0; c < k; c++)
                        {
                            item = (char)reader.Read();
                            while (item == 13 || item == 10)
                                item = (char)reader.Read();

                            if (item == '1')
                            {
                                lab[z, x, c] = -1;
                                d.n = z;
                                d.m = x;
                                d.k = c;
                                d.step = 1;
                                mq.Enqueue(d);
                            }
                            if (item == 'o')
                                lab[z, x, c] = -2;
                            if (item == '.')
                                lab[z, x, c] = 0;
                            if (item == '2')
                                lab[z, x, c] = -3;
                        }
            }
            
            bool ch = false;

            do
            {
                try
                {
                    d = mq.Dequeue();
                }
                catch (Exception)
                {
                }
                    if (d.n < n - 1 && lab[d.n + 1, d.m, d.k] == 0)
                    {
                        lab[d.n + 1, d.m, d.k] = d.step;
                        d1.n = d.n + 1;
                        d1.m = d.m;
                        d1.k = d.k;
                        d1.step = d.step + 1;
                        mq.Enqueue(d1);
                    }
                    else if (d.n < n - 1 && lab[d.n + 1, d.m, d.k] == -3)
                    {
                        ch = true;
                        break;
                    }
                    if (d.m > 0 && lab[d.n, d.m - 1, d.k] == 0)
                    {
                        lab[d.n, d.m - 1, d.k] = d.step;
                        d1.n = d.n;
                        d1.m = d.m - 1;
                        d1.k = d.k;
                        d1.step = d.step + 1;
                        mq.Enqueue(d1);
                    }
                    else if (d.m > 0 && lab[d.n, d.m - 1, d.k] == -3)
                    {
                        ch = true;
                        break;
                    }
                    if (d.m < m - 1 && lab[d.n, d.m + 1, d.k] == 0)
                    {
                        lab[d.n, d.m + 1, d.k] = d.step;
                        d1.n = d.n;
                        d1.m = d.m + 1;
                        d1.k = d.k;
                        d1.step = d.step + 1;
                        mq.Enqueue(d1);
                    }
                    else if (d.m < m - 1 && lab[d.n, d.m + 1, d.k] == -3)
                    {
                        ch = true;
                        break;
                    }
                    if (d.k > 0 && lab[d.n, d.m, d.k - 1] == 0)
                    {
                        lab[d.n, d.m, d.k - 1] = d.step;
                        d1.n = d.n;
                        d1.m = d.m;
                        d1.k = d.k - 1;
                        d1.step = d.step + 1;
                        mq.Enqueue(d1);
                    }
                    else if (d.k > 0 && lab[d.n, d.m, d.k - 1] == -3)
                    {
                        ch = true;
                        break;
                    }
                    if (d.k < k - 1 && lab[d.n, d.m, d.k + 1] == 0)
                    {
                        lab[d.n, d.m, d.k + 1] = d.step;
                        d1.n = d.n;
                        d1.m = d.m;
                        d1.k = d.k + 1;
                        d1.step = d.step + 1;
                        mq.Enqueue(d1);
                    }
                    else if (d.k < k - 1 && lab[d.n, d.m, d.k + 1] == -3)
                    {
                        ch = true;
                        break;
                    }
                } while (!ch);

            Console.WriteLine(5 * d.step);
            Console.Read();
        }
    }
}
