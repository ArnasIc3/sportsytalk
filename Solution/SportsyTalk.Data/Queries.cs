namespace SportsyTalk.Data
{
    internal class Queries
    {
        public const string GET_SPORTS_SQL = @"
            select * from sports order by title asc";

        public const string GET_FEEDS_BY_SPORT_SQL = @"
            select f.* from feeds f
            inner join feeds_sports fs on f.id = fs.feeds_id
            where fs.sports_id = @SportId
            order by f.title asc";

        public const string GET_FEEDS_FOR_HOME_SQL = @"
            select f.* from feeds f
            where f.showonhome = 1
            order by f.title asc";

        public const string GET_SPORTS_BY_EMAIL_SQL = @"
            select s.* from sports s
            inner join user_sports us on s.id = us.sports_id
            where us.email = @Email
            order by s.title asc";
        public const string SAVE_USER_SPORT = @"
            insert into user_sports(email, sports_id)
            values(@Email, @Sports_Id)";
        public const string DELETE_USER_SPORT = @"
            delete from user_sports where email = @Email and sports_id = @Sports_Id";
    }
}
