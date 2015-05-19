using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class SearchHit
    {
        public SearchHit(string name, string location, List<Music> m)
        {
            OwnerName = name;
            OwnerLocation = location;
            MusicFound = m;
        }

        public string OwnerLocation { get; private set; }
        public string OwnerName { get; private set; }
        public List<Music> MusicFound { get; private set; }
    }
}
