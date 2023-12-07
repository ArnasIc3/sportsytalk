using SportsyTalk.Data.Entities;
using SportsyTalk.Feeds;

namespace SportsyTalk.Web.Models
{
    public class SportDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public List<Portal> Portals { get; set; } = new();
        public List<RssFeed> Feeds { get; set; } = new();
    }
}
