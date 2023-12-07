using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsyTalk.Data
{
    internal class Queries
    {
        public const string GET_CATEGORIES_SPORTS_COUNT_SQL = @"select * from viewCategoryCount";

        public const string GET_SPORTS_BY_CATEGORY_SQL = @"
            select s.* from sports s
            inner join sport_categories sc on s.id = sc.sports_id
            where sc.categories_id = @CategoryId
            order by s.title asc";

        public const string GET_SPORTS_SQL = @"
            select * from sports order by title asc";

        public const string GET_CATEGORIES_SQL = @"
            select * from categories c
            order by c.title asc";

        public const string GET_FEEDS_BY_SPORT_SQL = @"
            select f.* from feeds f
            inner join feeds_sports fs on f.id = fs.feeds_id
            where fs.sports_id = @SportId
            order by f.title asc";

        public const string GET_PORTALS_SQL = @"
            select * from portals order by title asc";

        public const string GET_PORTALS_BY_SPORT_SQL = @"
            select p.* from feeds f
            inner join feeds_sports fs on f.id = fs.feeds_id
            inner join portals p on f.portals_id = p.id
            where fs.sports_id = @SportId
            order by p.title asc";
    }
}
