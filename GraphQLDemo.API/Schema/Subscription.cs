using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.API.Schema
{
    public class Subscription
    {
        public CourseType courseCreated([EventMessage]CourseType course) => course;
    }
}