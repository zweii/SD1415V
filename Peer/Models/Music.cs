using System;

namespace Models
{
    [Serializable]
    public class Music
    {
        public string Title { get; private set; }
        public string Url { get; private set; }
        public Format Format { get; private set; }
        public string Artist { get; private set; }
        public int Year { get; private set; }
        public string Album { get; private set; }

        public Music(string name, string url, Format formato, string artista, string album, int ano)
        {
            Title = name;
            Url = url;
            Format = formato;
            Artist = artista;
            Year = ano;
            Album = album;
        }

        public bool Contains(string search)
        {
            return Title.Contains(search) || Artist.Contains(search) || Album.Contains(search);
        }
        public override string ToString()
        {
            return " Music Info { " +
                 "\n   Title:" + Title +
                 "\n   Artist:" + Artist +
                 "\n   Album:" + Album +
                 "\n   Artist:" + Artist +
                 "\n   Year:" + Year +
                 "\n   Format:" + Format +
                 "\n   Url:" + Url +
               "\n }";
        }
    }
}
