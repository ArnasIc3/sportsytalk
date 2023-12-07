using SportsyTalk.Data.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

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
        public List<Category> GetCategories()
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Category>(conn, Queries.GET_CATEGORIES_SQL).ToList();
        }

        public List<CategorySportsCount> GetCategoriesSportsCount()
        {
            using var conn = GetConnection();
            return SqlMapper.Query<CategorySportsCount>(conn, Queries.GET_CATEGORIES_SPORTS_COUNT_SQL).ToList();
        }

        public List<Sport> GetSportsByCategory(int categoryId)
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Sport>(conn, Queries.GET_SPORTS_BY_CATEGORY_SQL, new { CategoryId = categoryId }).ToList();
        }

        public List<Sport> GetSports()
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Sport>(conn, Queries.GET_SPORTS_SQL).ToList();
        }

        public List<Portal> GetPortals()
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Portal>(conn, Queries.GET_PORTALS_SQL).ToList();
        }

        public List<Feed> GetFeedsBySport(int sportId)
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Feed>(conn, Queries.GET_FEEDS_BY_SPORT_SQL, new { SportId = sportId }).ToList();
        }

        public List<Portal> GetPortalsBySport(int sportId)
        {
            using var conn = GetConnection();
            return SqlMapper.Query<Portal>(conn, Queries.GET_PORTALS_BY_SPORT_SQL, new { SportId = sportId }).ToList();
        }
    }
}