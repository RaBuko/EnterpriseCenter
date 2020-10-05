using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterApp.Algos
{
    public class MagicSquare
    {
        private readonly Random random = new Random();

        public int Size;

        private int[,] data;

        public MagicSquare(params int [] members)
        {
            if (Math.Sqrt(members.Length) % 1 != 0)
            {
                throw new ArgumentException("Z takich argumentów nie wyjdzie kwadrat");
            }

            Size = (int)Math.Sqrt(members.Length);
            data = new int[Size, Size];

            int i = 0;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    data[x, y] = members[i++];
                }
            }            
        }

        public MagicSquare(int size)
        {
            Size = size;
            data = new int[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    data[x,y] = random.Next(10);
                }
            }
        }

        public bool IsMagic()
        {
            int sum, prevSum = 0;
            for (int x = 0; x < Size; x++)
            {
                sum = 0;
                for (int y = 0; y < Size; y++)
                {
                    sum += data[x,y];
                }

                if (sum != prevSum && x != 0)
                {
                    return false;
                }
                prevSum = sum;
            }

            for (int y = 0; y < Size; y++)
            {
                sum = 0;
                for (int x = 0;  x < Size;  x++)
                {
                    sum += data[x,y];
                }

                if (sum != prevSum)
                {
                    return false;
                }
                prevSum = sum;
            }

            return true;
        }

        public int this[int x, int y]
        {
            get => data[x,y];
            set => data[x,y] = value;
        }
    }
}
