using System;
using System.Collections.Generic;

namespace Models
{
    public class MySearchs
    {
        public int ID { get; private set; }
        public SearchQuery searchQuery;
        private List<SearchHit> _answers = new List<SearchHit>();

        public MySearchs(int size, SearchQuery ret)
        {
            ID = size;
            searchQuery = ret;
        }

        public void AddHit(SearchHit sh)
        {
           lock(_answers) { _answers.Add(sh); }
        }
        public List<SearchHit> GetHits() { return _answers; }
    }
}