using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Peer
{
    [Serializable]
    class Configuration
    {
        private String _location;
        private String _name;
        private String _musicFile;
        private String[] _knownPeers;

        public Configuration(){
            _knownPeers = new String[0];
        }

        public String getLocation()
        {
            return this._location;
        }

        public void setLocation(String location)
        {
            this._location = location;
        }

        public String getName()
        {
            return this._name;
        }

        public void setName(String name)
        {
            this._name = name;
        }

        public String getMusicList()
        {
            return this._musicFile;
        }

        public void setMusicFile(String fileName)
        {
            this._musicFile= fileName;
        }

        public String[] getKnownPeers()
        {
            return this._knownPeers;
        }

        public void addPeer(String name, String location)
        {
            String[] aux = new String[_knownPeers.Length + 1];
            for (int i = 0; i < _knownPeers.Length; i++)
            {
                aux[i] = _knownPeers[i];
            }
            aux[_knownPeers.Length] = name + "|" + location;
            _knownPeers = aux;
        }

        public void Save(string path)
        {   
            IFormatter formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static Configuration Load(string path)
        {
            IFormatter formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            Configuration obj = (Configuration)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

    }
}
