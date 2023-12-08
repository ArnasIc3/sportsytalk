using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsyTalk.Feeds
{
    public class RssFeedItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string LinkUrl { get; set; } = "";
    }
    public class RssFeed
    {
        public RssFeed() { }
        public List<RssFeedItem> Items { get; set; } = new List<RssFeedItem>();
    }
}
