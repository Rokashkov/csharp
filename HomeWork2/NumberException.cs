using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    internal class NumberException : Exception
    {
        public int Index { get; set; }
        public NumberException(string Message, int index): base(Message) {
            Index = index;
        }
    }
}
