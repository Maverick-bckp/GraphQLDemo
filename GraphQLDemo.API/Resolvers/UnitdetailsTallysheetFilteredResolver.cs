using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.API.Resolvers
{
    [ExtendObjectType("Tallysheets")]
    public class UnitdetailsTallysheetFilteredResolver
    {
        public UnitdetailsTallysheets getTallysheetDataFiltered([Service] IUnitdetailsTallysheets tallysheets)
        {
            return tallysheets.getTallysheetDataFiltered();
        }
    }
}
