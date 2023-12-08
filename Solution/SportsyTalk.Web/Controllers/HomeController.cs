using Microsoft.AspNetCore.Mvc;
using SportsyTalk.Web.Models;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Net;
using SportsyTalk.Feeds;

namespace SportsyTalk.Web.Controllers
{
    public class HomeController : BaseController
    {
        
        public HomeController(ILogger<HomeController> logger, IConfiguration config, HttpClient httpClient) : base(logger, config, httpClient)
        {
            
        }

        List<SportMenuItemModel> GetSportsMenuItems()
        {
            var all_sports = this.Data.GetSports();
            List<SportMenuItemModel> items = new();
            foreach (var sport in all_sports)
            {
                var menu_item = new SportMenuItemModel()
                {
                    Id = sport.Id,
                    Title = sport.Title
                };
                items.Add(menu_item);
            }
            return items;
        }

        public async Task<IActionResult> Index(int id = 0)
        {
            HomeModel model = new();
            model.SportMenuItems = this.GetSportsMenuItems();
            FeedReader freader = new FeedReader(this._http);
         
            if (model.SportMenuItems.Any())
            {
                id = id == 0 ? model.SportMenuItems.First().Id : id;
                var selected = model.SportMenuItems.First(item => item.Id == id);
                var feeds = this.Data.GetFeedsBySport(id);
                model.SelectedSport = new SportDetailsModel()
                {
                    Id = id,
                    Title = selected.Title,
                    Portals = this.Data.GetPortalsBySport(id),
                };
                foreach(var feed in feeds)
                {
                    model.SelectedSport.Feeds.Add(await freader.GetFeed(feed.Url));
                }
            }
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}