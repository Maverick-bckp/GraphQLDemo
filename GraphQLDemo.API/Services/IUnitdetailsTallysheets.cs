using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Services
{
    public interface IUnitdetailsTallysheets
    {
        List<UserRole> getTallysheetData();
        List<UserSession> getUserSessions();
        UnitdetailsTallysheets getTallysheetDataFiltered();
    }
}
