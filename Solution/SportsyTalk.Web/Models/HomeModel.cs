using SportsyTalk.Feeds;

namespace SportsyTalk.Web.Models
{
	public class HomeModel
	{
		public List<SportMenuItemModel> SportMenuItems { get; set; } = new();
		public List<RssFeed> HomeFeeds { get; set; } = new();
	}
}
