using System.Xml.Linq;
using System.Xml.XPath;
namespace SportsyTalk.Feeds
{

    public class FeedReader
    {
        HttpClient http;
        public FeedReader(HttpClient httpClient)
        {
            this.http = httpClient;
        }

        public async Task<RssFeed> GetFeed(string url)
        {
            var feed = new RssFeed();
            var rss = await this.http.GetStringAsync(url);
            var rssXml = XDocument.Parse(rss);
            var xmlFeedItems = rssXml.XPathSelectElements("/rss/channel/item");
            foreach (var xmlItem in xmlFeedItems)
            {
                var item = new RssFeedItem();
                item.Title = xmlItem.Element("title")?.Value ?? "";
                item.Description = xmlItem.Element("description")?.Value ?? "";
                var enclosure = xmlItem.Elements().FirstOrDefault(el => el.Name.LocalName == "enclosure");
                var thumbnail = xmlItem.Elements().FirstOrDefault(el => el.Name.LocalName == "thumbnail");
                var link = xmlItem.Elements().FirstOrDefault(el => el.Name.LocalName == "link");
                var pubDate = xmlItem.Elements().FirstOrDefault(el => el.Name.LocalName == "pubDate");
                if (enclosure != null)
                {
                    item.ImageUrl = enclosure.Attribute("url")?.Value ?? "";
                }
                else if (thumbnail != null)
                {
                    item.ImageUrl = thumbnail.Attribute("url")?.Value ?? "";
                }

                if (link != null)
                {
                    item.LinkUrl = link.Value;
                }

                if (pubDate != null)
                {
                    item.PubDate = pubDate.Value;
                }
                feed.Items.Add(item);
            }
            return feed;
        }

    }
}