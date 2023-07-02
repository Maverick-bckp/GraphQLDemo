using Dapper;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GraphQLDemo.API.Repositories
{
    public class UnitTallysheetRepository : IUnitdetailsTallysheets
    {
        private readonly IConfiguration _configuration;
        private IDbConnection Connection
        {
            get
            {
                return new OracleConnection(_configuration.GetConnectionString("connINTERFACE"));
            }
        }

        public UnitTallysheetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UserRole> getTallysheetData()
        {
            dynamic result = new List<UserRole>();
            try
            {
                using (var connection = Connection)
                {
                    var sql = "select * from USER_ROLE";
                    result = connection.Query<UserRole>(sql).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<UserSession> getUserSessions()
        {
            dynamic result = new List<UserSession>();
            try
            {
                using (var connection = Connection)
                {
                    var sql = "select * from USER_SESSION";
                    result = connection.Query<UserSession>(sql).ToList();
                }
            }
            catch(Exception ex) { }
            return result;
        }

        public UnitdetailsTallysheets getTallysheetDataFiltered()
        {
            dynamic result = new UnitdetailsTallysheets();
            try
            {
                using (var connection = Connection)
                {
                    var sql = "select * from UNITDETAILS_TALLYSHEETS where rownum = 1";
                    result = connection.Query<UnitdetailsTallysheets>(sql).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
