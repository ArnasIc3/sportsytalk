using SportsyTalk.Data.Entities;
namespace SportsyTalk.Web.Models
{
    public class HomeOldModel
    {
        public List<CategoryMenuItemModel> CategoryMenuItems { get; set; } = new ();
    }

    public class HomeModel
    {
        public List<SportMenuItemModel> SportMenuItems { get; set; } = new ();
        public SportDetailsModel? SelectedSport { get; set; }
    }
}
