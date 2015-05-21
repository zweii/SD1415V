using System;
using System.Collections.Generic;
using Peer;
using System.Threading.Tasks;

namespace Models
{

    public class PeerUser
    {
        public string name;
        public string location;
        private MusicBox _box;
        private List<KeyValuePair<string, string>> _knownPeers;
        private List<SearchQuery> _lastRequests = new List<SearchQuery>();
        private List<MySearchs> _mySearchs = new List<MySearchs>();

        public PeerUser(string name, string location)
        {
            this.name = name;
            this.location = location;
        }

        public PeerUser(string name, string location, MusicBox box, List<KeyValuePair<string, string>> knownPeers) : this(name, location)
        {
            _box = box;
            _knownPeers = knownPeers;
        }

        public SearchQuery GotHit(int id, SearchHit sh)
        {
            MySearchs ms = _mySearchs.Find((s) => s.ID == id);
            ms.AddHit(sh);
            return ms.searchQuery;
        }

        public bool AllreadyReceived(SearchQuery searchQuery)
        {
            return _lastRequests.Exists((s) => s.ID == searchQuery.ID && s.OwnerName == searchQuery.OwnerName);
        }

        public void ReceivedFrom(string lastName, string lastLocation)
        {

            KeyValuePair<string, string> peer = new KeyValuePair<string, string>(lastName, lastLocation);
            lock(_knownPeers) {
                if (!_knownPeers.Contains(peer)) _knownPeers.Add(peer);
            }
        }

        public List<Music> FulfillRequest(string queryString)
        {
            return _box.Search(queryString);
        }

        public void Propagate(SearchQuery searchQuery)
        {
            string auxLastName = searchQuery.LastName;
            string auxLastLocation = searchQuery.LastLocation;
            searchQuery.LastName = name;
            searchQuery.LastLocation = location;
            foreach (KeyValuePair<string, string> pair in _knownPeers)
            {
                if (searchQuery.OwnerName != pair.Key && searchQuery.OwnerLocation != pair.Value && auxLastName != pair.Key && auxLastLocation != pair.Value)
                    Task.Run(() => App.SendSearchRequestTo(pair.Key, pair.Value, searchQuery)) ;
            }
        }

        public void Success(SearchQuery sq,List<Music> m)
        {
            SearchHit sh = new SearchHit(name, location, m);
            App.SendHitRequestTo(sq.OwnerName, sq.OwnerLocation, sq.ID, sh);
        }

        public SearchQuery CreateSearch(string searchQuery)
        {
            int size = _mySearchs.Count + 1;
            SearchQuery ret = new SearchQuery(size, name, location, searchQuery, App.TTL);
            _mySearchs.Add(new MySearchs(size, ret));
            return ret;
        }

        public void addReceived(SearchQuery searchQuery)
        {
            lock(_lastRequests) { _lastRequests.Add(searchQuery); }
        }
    }

}
