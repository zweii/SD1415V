using Cliente;
using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class SearchQuery
    {

        public SearchQuery(int size, string name, string location, string searchQuery, int tTL)
        {
            ID = size;
            OwnerName = name;
            OwnerLocation = location;
            LastName = name;
            LastLocation = location;
            QueryString = searchQuery;
            TTL = tTL;
            Hops = 0;
        }

        public int ID { get; private set; }
        public string OwnerName { get; private set; }
        public string OwnerLocation { get; private set; }
        public string LastName { get; set; }
        public string LastLocation { get; set; }
        public int TTL { get; private set; } // max number of hops ( Time To Live )
        public int Hops { get; private set; }
        public string QueryString { get; private set; }

        public void Receive(PeerUser peer, PeerClient pc)
        {
            //RECEIVING REQUEST START

            //LOG REQUEST
            pc.EventLogDisplay.AppendLine(string.Format(" {0}:{1} -> Request Received From {2}:{3} -- Searching for '{4}' ", OwnerName, ID, LastName, LastLocation, QueryString));

            //CHECK IF YOU KNOW PEER
            //    IF NO ADD IT TO KNOWN PEER LIST
            peer.ReceivedFrom(LastName, LastLocation);

            //CHECK IF U HAVE RECEIVED THIS REQUEST
            //    IF YES DISCARD -LOG DISCARD REASON //END
            if (peer.AllreadyReceived(this)) { pc.EventLogDisplay.AppendLine(string.Format(" {0}:{1} -> Request allready received before dropping request...", OwnerName, ID)); return; }

            //DECREMENT NUMBER OF HOPS
            TTL--;
            //CHECK IF NUMBER OF HOPS EXCEEDS MAXIMUM
            //    IF YES DISCARD -LOG DISCARD REASON  //END
            if (TTL == 0) { pc.EventLogDisplay.AppendLine(string.Format(" {0}:{1} -> Request time to live has reached 0, dropping request...", OwnerName, ID)); return; }
            Hops++;

            //CHECK IF YOU CAN FULFILL REQUEST
            //    IF NO PROPAGATE REQUEST FOR YOUR KNOWN PEERS -LOG RELAY //END
            List<Music> m = peer.FulfillRequest(QueryString);
            if (m.Count == 0) { peer.Propagate(this); pc.EventLogDisplay.AppendLine(string.Format(" {0}:{1} -> Request has been propagated to known peers", OwnerName, ID)); return; }

            //RETURN TO REQUEST OWNER MUSIC OBJECT
            //LOG SUCCESS
            peer.Success(this,m);
            pc.EventLogDisplay.AppendLine(string.Format(" {0}:{1} -> Request has been answered!", OwnerName, ID));

        }

    }
}
