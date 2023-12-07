using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsyTalk.Data.Entities
{
    public class Feed : EntityBase
    {
        public int Portals_Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";

    }
}
