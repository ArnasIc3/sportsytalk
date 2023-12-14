namespace SportsyTalk.Web.Models
{
    public class CustomizeModel
    {
        public List<SportMenuItemModel> SportMenuItems { get; set; } = new();
        public List<SportMenuItemModel> SelectedSportItems { get; set; } = new();
    }
}
