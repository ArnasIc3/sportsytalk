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
    public class HomeOldController : BaseController
    {
        
        public HomeOldController(ILogger<HomeController> logger, IConfiguration config, HttpClient httpClient) : base(logger, config, httpClient)
        {
            
        }

        List<CategoryMenuItemModel> GetCategoryMenuItems()
        {
            var categories = this.Data.GetCategories();
            var cat_sport_counts = this.Data.GetCategoriesSportsCount();
            List<CategoryMenuItemModel> items = new List<CategoryMenuItemModel>();
            foreach (var category in categories)
            {
                var menu_item = new CategoryMenuItemModel()
                {
                    Id = category.Id,
                    Title = category.Title,
                    Image = category.Image,
                    HtmlFile = category.HtmlFile,
                    SportsCount = cat_sport_counts.First(item => item.Id == category.Id).SportsCount
                };
                items.Add(menu_item);
            }
            return items;
        }

        List<SportDetailsModel> GetSports(int categoryId)
        {
            List<SportDetailsModel> items = new List<SportDetailsModel>();
            var sports = this.Data.GetSportsByCategory(categoryId);
            foreach(var sport in sports)
            {
                var sportModel = new SportDetailsModel()
                {
                    Id = sport.Id,
                    Title = sport.Title
                };
                items.Add(sportModel);
            }
            return items;
        }

        public IActionResult Index()
        {
            HomeOldModel model = new HomeOldModel();
            model.CategoryMenuItems = this.GetCategoryMenuItems();
            return View(model);
        }

        public IActionResult CategoryDetails(int id)
        {
            CategoryDetailsModel model = new CategoryDetailsModel();
            model.AllCategories = this.GetCategoryMenuItems();
            model.SelectedCategory = model.AllCategories.FirstOrDefault(item => item.Id == id);
            if(model.SelectedCategory != null)
            {
                model.Sports = this.GetSports(id);
            }
            return View(model);
        }
        public async Task<IActionResult> Privacy()
        {
            FeedReader freader = new FeedReader(this._http);
            var rss = await freader.GetFeed("https://www.espn.com/espn/rss/nba/news");
            return View("RssFeed", rss);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}