using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Indexers
{
    class IndexedCollection
    {
        private Dictionary<string, int> _data;

        public IndexedCollection()
        {
            _data = new Dictionary<string, int>
            {
                {"one",  1},
                {"two", 2 },
                {"three", 3 }
            };
        }

        public int this[int index]
        {
            get => _data[_data.Keys.ElementAtOrDefault(index - 1)];
        }

        public int this[string index]
        {
            get => _data[index];
            set => _data.Add(index, value);
        }
    }
}
