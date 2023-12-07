using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsyTalk.Data.Entities
{
    public class Portal : EntityBase
    {
        public string Title { get; set; } = "";
        public string WWW { get; set; } = "";
        public string Logo { get; set; } = "";
    }
}
