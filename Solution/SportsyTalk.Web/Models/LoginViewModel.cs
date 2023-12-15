using Microsoft.AspNetCore.Authentication;

namespace SportsyTalk.Web.Models
{
    public class LogInViewModel
    {
        public bool ShowTitle { get; set; } = true;
        public string? ReturnUrl { get; set; }

        public List<AuthenticationScheme> ExternalLogins { get; set; } = new();
    }
}
