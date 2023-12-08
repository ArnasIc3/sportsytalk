namespace SportsyTalk.Web.Models
{
    public class CategoryDetailsModel
    {
        public CategoryMenuItemModel? SelectedCategory { get; set; }
        public List<CategoryMenuItemModel> AllCategories { get; set; } = new List<CategoryMenuItemModel>();
        public List<SportDetailsModel> Sports { get; set; } = new List<SportDetailsModel>();
    }
}
