using Dapper;
using Microsoft.Data.SqlClient;
using SportsyTalk.Data.Entities;

namespace SportsyTalk.Data
{
    public class Repository
    {
        string connectionString;
        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public List<Sport> GetSports()
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Sport>(conn, Queries.GET_SPORTS_SQL).ToList();
        }
        public List<Sport> GetSports(string email)
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Sport>(conn, Queries.GET_SPORTS_BY_EMAIL_SQL, new { Email = email }).ToList();
        }

        public List<Feed> GetFeedsBySport(int sportId)
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Feed>(conn, Queries.GET_FEEDS_BY_SPORT_SQL, new { SportId = sportId }).ToList();
        }

        public List<Feed> GetFeedsForHome()
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Feed>(conn, Queries.GET_FEEDS_FOR_HOME_SQL).ToList();
        }

        public void Save(string email, int sportsId)
        {
            using var conn = GetConnection();
            SqlMapper.Execute(conn, Queries.SAVE_USER_SPORT, new { Email = email, Sports_ID = sportsId });
        }
        public void Delete(string email, int sportsId)
        {
            using var conn = GetConnection();
            SqlMapper.Execute(conn, Queries.DELETE_USER_SPORT, new { Email = email, Sports_ID = sportsId });
        }
    }
}