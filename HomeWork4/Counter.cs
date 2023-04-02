using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Counter
    {
        public int Count { get; set; } = 0;

        public delegate void CountHandler();

        public event CountHandler? Notify;

        public void Increment()
        {

            while (Count < 100) {
                if (Count == 77)
                {
                    Notify?.Invoke();
                }

                Console.WriteLine(Count);
                Count++;
            }
        }

    }
}
