using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.API.Resolvers
{
    [ExtendObjectType("Tallysheets")]
    public class UnitdetailsTallysheetsResolver
    {
        public List<UserRole> getTallysheetData([Service] IUnitdetailsTallysheets tallysheets)
        {
           return tallysheets.getTallysheetData();
        }

        public List<UserSession> getUserSessionData([Service] IUnitdetailsTallysheets tallysheets)
        {
            return tallysheets.getUserSessions();
        }
    }
}
