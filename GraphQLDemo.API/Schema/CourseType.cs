namespace GraphQLDemo.API.Schema
{
    public enum Subject
    {
        Mathematics,
        Science,
        History
    }

    public class CourseType
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<InstructorType> Instructor { get; set; }
        public IEnumerable<StudentType> students { get; set; }
    }
}
