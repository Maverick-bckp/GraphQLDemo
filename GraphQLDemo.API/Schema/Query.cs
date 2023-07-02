using Bogus;
using HotChocolate;

namespace GraphQLDemo.API.Schema
{
    public class Query
    {
        Faker<InstructorType> instructorFaker;
        Faker<StudentType> studentFaker;
        Faker<CourseType> courseFaker;

        public Query()
        {
             instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.ID, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => f.Random.Double(0, 4));

             studentFaker = new Faker<StudentType>()
                .RuleFor(c => c.ID, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

             courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, f => instructorFaker.Generate(3))
                .RuleFor(c => c.students, f => studentFaker.Generate(3));

        }
        public IEnumerable<CourseType> getCourses()
        {        
            List<CourseType> courses = courseFaker.Generate(5);
            return courses;
        }

        public CourseType getCourseByID(Guid id)
        {
            CourseType course = courseFaker.Generate();
            course.id = id;
            return course;
        }
    }
}
