namespace SportsyTalk.Data.Entities
{
	public class Feed : EntityBase
	{
		public int Portals_Id { get; set; }
		public string Title { get; set; } = "";
		public string Url { get; set; } = "";
		public bool ShowOnHome { get; set; }

	}
}
