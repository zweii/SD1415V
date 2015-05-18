using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Models
{
    [Serializable]
    public class MusicBox
    {
        private List<Music> _musics;

        public MusicBox(List<Music> musics)
        {
            _musics = musics;
        }
        public MusicBox()
        {
            _musics = new List<Music>();
        }
        public void AddMusic(Music music)
        {
            if(!_musics.Contains(music))_musics.Add(music);
        }
        public List<Music> Search(string search)
        {
            return _musics.FindAll((s) => s.Contains(search));
        }
        public override string ToString()
        {
            string ret="Music Box Songs:[\n";
            foreach(Music m in _musics) { ret+= m.ToString()+"\n"; }
            return ret+"\n]";
        }
        public void Save(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static MusicBox Load(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            MusicBox obj = (MusicBox)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
    
}
