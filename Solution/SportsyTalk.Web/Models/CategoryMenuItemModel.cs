namespace SportsyTalk.Web.Models
{
    public class CategoryMenuItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Image { get; set; } = "";
        public string HtmlFile { get; set; } = "";
        public int SportsCount { get; set; } = 0;
    }
}
