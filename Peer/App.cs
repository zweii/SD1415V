using Models;
using Cliente;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;

namespace Peer
{

    [Serializable]
    public class SearchQueryHandler : MarshalByRefObject , ISearchQueryHandler 
    {
        private int _requestsReceived = 0;
        public void Search(SearchQuery sq)
        {
            Task.Run(() =>
                {
                    Interlocked.Increment(ref _requestsReceived);
                    sq.Receive(App.peer, App.peerClient);
                }
            );
        }
    }

    [Serializable]
    public class SearchHitHandler : MarshalByRefObject, ISearchHitHandler
    {

        private int _hitsReceived = 0;
        public void Hit(int id,SearchHit sh)
        {
            Task.Run(() =>
                {
                    SearchQuery sq = App.peer.GotHit(id, sh);
                    App.peerClient.EventLogDisplay.AppendLine(string.Format(" SearchQuery {0} searching for '{1}' has got results from {2}:{3}", sq.ID, sq.QueryString, sh.OwnerName, sh.OwnerLocation));
                    Interlocked.Increment(ref _hitsReceived);
                }
            );
        }
    }

    public class App
    {
        public static PeerUser peer;
        public static PeerClient peerClient;
        public static int TTL = 10;

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Pleas insert xml config name");
            }
            Configuration c = Configuration.Load(args[0]);

            MusicBox box = new MusicBox();
            box = MusicBox.Load(c.getMusicList());

            List<KeyValuePair<string, string>> knownPeers = ConfUtil.parseKnownPeers(c.getKnownPeers());

            peer = new PeerUser(c.getName(), c.getLocation(), box, knownPeers);
            peerClient = new PeerClient();
            InitiateServer(peer.name, peer.location);

            peerClient.searchButton.Click += OnClick;

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(peerClient);
        }

        private static void OnClick(object sender, EventArgs e)
        {
            CreateSearch(peerClient.searchText.Text);
        }

        public static void SendSearchRequestTo(string name, string location, SearchQuery searchQuery)
        {
            ISearchQueryHandler sqh = (ISearchQueryHandler)Activator.GetObject(typeof(SearchQueryHandler), "tcp://" + location + "/searchQuery");
            //RemotingConfiguration.RegisteredActivatedClientType(typeof(SearchQuery), "tcp://" + location + "/searchQuery"); // NAO SEI O QUE ISTO
            peerClient.EventLogDisplay.AppendLine(string.Format("Search request send to {0}:{1}, looking for '{2}'",name,location, searchQuery.QueryString));
            try
            {
                sqh.Search(searchQuery);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                peerClient.EventLogDisplay.AppendLine(string.Format("Error connecting to peer {0}:{1} ", name, location));
            }
        }
        public static void SendHitRequestTo(string name, string location, int id,SearchHit searchHit)
        {
            ISearchHitHandler shh = (ISearchHitHandler)Activator.GetObject(typeof(SearchHitHandler), "tcp://" + location + "/searchHit");
            //RemotingConfiguration.RegisteredActivatedClientType(typeof(SearchHit), "tcp://" + location + "/searchHit"); // NAO SEI O QUE ISTO
            peerClient.EventLogDisplay.AppendLine(string.Format("Hit request send to {0}:{1}", name, location));

            try{
                shh.Hit(id, searchHit);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                peerClient.EventLogDisplay.AppendLine(string.Format("Error connecting to peer {0}:{1} ", name, location));
            }
        }

        public static void CreateSearch(string searchQuery)
        {
            SearchQuery sq = peer.CreateSearch(searchQuery);
            peerClient.EventLogDisplay.AppendLine(string.Format("Search created, looking for '{0}'", sq.QueryString));
            peer.Propagate(sq);
        }

        private static void InitiateServer(string name, string location)
        {

            //this.EventLogDisplay.("Inicio do CalcServer");
            TcpChannel ch = new TcpChannel(GetPortFromdomain(location));

            ChannelServices.RegisterChannel(ch, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(SearchQueryHandler),
                "searchQuery",
            //WellKnownObjectMode.SingleCall); // cada pedido é servido por um novo objecto
            WellKnownObjectMode.Singleton); // pedidos servidos pelo mesmo objecto

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(SearchHitHandler),
                "searchHit",
            //WellKnownObjectMode.SingleCall); // cada pedido é servido por um novo objecto
            WellKnownObjectMode.Singleton); // pedidos servidos pelo mesmo objecto
        }

        private static int GetPortFromdomain(string location)
        {
            return Int32.Parse(location.Split(new Char[] { ':' })[1]);
        }
    }
}
