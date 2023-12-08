using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsyTalk.Data.Entities
{
    public class CategorySportsCount : EntityBase
    {
        public int SportsCount { get; set; }
    }
}
