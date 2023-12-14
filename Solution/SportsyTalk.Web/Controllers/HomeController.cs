using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsyTalk.Feeds;
using SportsyTalk.Web.Models;

namespace SportsyTalk.Web.Controllers
{
    public class HomeController : BaseController
    {
        private SignInManager<IdentityUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, HttpClient httpClient, SignInManager<IdentityUser> signIn) : base(logger, config, httpClient)
        {
            _signInManager = signIn;
        }

        List<SportMenuItemModel> GetSportsMenuItems(string? email = null)
        {
            var all_sports = email == null ? this.Data.GetSports() : this.Data.GetSports(email);
            List<SportMenuItemModel> items = new();
            foreach (var sport in all_sports)
            {
                var menu_item = new SportMenuItemModel()
                {
                    Id = sport.Id,
                    Title = sport.Title,
                    Photo = sport.Photo
                };
                items.Add(menu_item);
            }
            return items;
        }

        public async Task<IActionResult> Index(int id = 0)
        {
            HomeModel model = new()
            {
                SportMenuItems = this.GetSportsMenuItems()
            };
            var feeds = this.Data.GetFeedsForHome();
            FeedReader freader = new(this._http);
            foreach (var feed in feeds)
            {
                model.HomeFeeds.Add(await freader.GetFeed(feed.Url));
            }
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> News(int sportId = 0)
        {
            NewsModel model = new();
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var email = User.Identity.Name;
                model.SportMenuItems = this.GetSportsMenuItems(email);
                //No sports selected, need to redirect to customization screen
                if (!model.SportMenuItems.Any())
                {
                    return LocalRedirect(Url.Action("Customize", "Home") ?? "/");
                }
                model.SelectedSport = sportId == 0 ? model.SportMenuItems.FirstOrDefault() : model.SportMenuItems.FirstOrDefault(sport => sport.Id == sportId);
                if (model.SelectedSport != null)
                {
                    var feeds = this.Data.GetFeedsBySport(model.SelectedSport.Id);
                    FeedReader freader = new(this._http);
                    foreach (var feed in feeds)
                    {
                        var rssFeed = await freader.GetFeed(feed.Url);
                        rssFeed.Title = model.SelectedSport.Title ?? "";
                        model.Feeds.Add(rssFeed);
                    }
                }
            }
            else
            {
                model.SportMenuItems = this.GetSportsMenuItems();
                model.LoginModel = new()
                {
                    ReturnUrl = Url.Action("News", "Home"),
                    ShowTitle = false,
                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };
                var feeds = this.Data.GetFeedsForHome();
                FeedReader freader = new(this._http);
                foreach (var feed in feeds)
                {
                    var rssFeed = await freader.GetFeed(feed.Url);
                    rssFeed.Title = "Top Headlines";
                    model.Feeds.Add(rssFeed);
                }
            }

            return View(model);
        }
        [Authorize]
        public IActionResult Customize()
        {
            var email = User.Identity?.Name;
            CustomizeModel model = new()
            {
                SportMenuItems = this.GetSportsMenuItems(),
                SelectedSportItems = this.GetSportsMenuItems(email),
            };
            return View(model);
        }

        [Authorize]
        public IActionResult ToggleSport(int sportId)
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var email = User.Identity.Name ?? "empty";
                var userSports = this.Data.GetSports(email);
                var selectedSport = userSports.FirstOrDefault(item => item.Id == sportId);
                if (selectedSport == null)
                {
                    this.Data.Save(email, sportId);
                }
                else
                {
                    this.Data.Delete(email, sportId);
                }
                return Json(new { sportId = sportId });
            }

            return Empty;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}