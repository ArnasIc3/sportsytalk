namespace SportsyTalk.Feeds
{
    public class RssFeedItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string? LinkUrl { get; set; }
        public string? PubDate { get; set; }
    }
    public class RssFeed
    {
        public RssFeed() { }
        public string Title { get; set; } = "";
        public List<RssFeedItem> Items { get; set; } = new List<RssFeedItem>();
    }
}
