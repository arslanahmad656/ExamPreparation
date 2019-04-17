using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project8.Serializtion
{
    [Serializable]
    class MusicDataStore
    {
        private List<Artist> artists = new List<Artist>();
        private List<MusicTrack> tracks = new List<MusicTrack>();

        public static MusicDataStore MusicStore => new MusicDataStore();

        private MusicDataStore()
        {
            Seed();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Total artists: {artists.Count}{Environment.NewLine}");
            sb.Append($"Total tracks: {tracks.Count}{Environment.NewLine}");
            sb.Append($"Tracks:{Environment.NewLine}");
            tracks.ForEach(track => sb.Append($"{track}{Environment.NewLine}"));
            sb.Append("--------------------------------------------------------");

            return sb.ToString();
        }

        private void Seed()
        {
            Debug.WriteLine("Seeding music data store...");
            string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
            string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

            Random rand = new Random(1);

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { Name = artistName };
                artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        Artist = newArtist,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    tracks.Add(newTrack);
                }
            }

            Debug.Indent();
            foreach (MusicTrack track in tracks)
            {
                Debug.WriteLine("Added Artist:{0} Title:{1} Length:{2}",
                    track.Artist.Name, track.Title, track.Length);
            }
            Debug.Unindent();
        }
    }
}
