using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    internal class Record
    {
        public string Ext { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Record(string ext, string name, DateTime updatedAt)
        {
            Ext = ext;
            Name = name;
            UpdatedAt = updatedAt;
        }
    }
}
