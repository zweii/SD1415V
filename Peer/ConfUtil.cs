using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Peer
{
    class ConfUtil
    {

        public static List<KeyValuePair<string, string>> parseKnownPeers(String[] array)
        {
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < array.Length; i++)
            {
                String aux = array[i];
                String[] aux2 = aux.Split( '|' );
                ret.Add(new KeyValuePair<string, string>(aux2[0], aux2[1]));
            }
            return ret;
        }
     

        private static string readFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
