using SportsyTalk.Feeds;

namespace SportsyTalk.Web.Models
{
    public class NewsModel
    {
        public List<SportMenuItemModel> SportMenuItems { get; set; } = new();
        public SportMenuItemModel? SelectedSport { get; set; }
        public List<RssFeed> Feeds { get; set; } = new();
        public LogInViewModel? LoginModel { get; set; }
    }
}
