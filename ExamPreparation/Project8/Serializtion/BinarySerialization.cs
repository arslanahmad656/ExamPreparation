using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project8.Serializtion
{
    static class BinarySerialization
    {
        public static void Run()
        {
            var store = GetMusicStore();
        }

        static MusicDataStore GetMusicStore()
        {
            var store = MusicDataStore.MusicStore;

            Debug.WriteLine(store);

            return store;
        }
    }
}
