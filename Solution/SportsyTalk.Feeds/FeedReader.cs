using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
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
            foreach(var xmlItem in xmlFeedItems)
            {
                var item = new RssFeedItem();
                item.Title = xmlItem.Element("title")?.Value ?? "";
                item.Description = xmlItem.Element("description")?.Value ?? "";
                item.ImageUrl = xmlItem.Element("enclosure")?.Attribute("url")?.Value ?? "";
                feed.Items.Add(item);
            }
            return feed;
        }

    }
}