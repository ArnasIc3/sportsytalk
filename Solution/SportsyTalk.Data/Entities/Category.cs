using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsyTalk.Data.Entities
{
    public class Category : EntityBase
    {
        public string Title { get; set; } = "";
        public string Image { get; set; } = "";
        public string HtmlFile { get; set; } = "";
    }
}
