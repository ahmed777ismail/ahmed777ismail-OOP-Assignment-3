namespace Assignment.Generics;
public sealed class CourseStore
{
    private readonly List<Course> _courses = [];
    public void Add(Course course) => _courses.Add(course);
    public Course? GetById(int id) { foreach (var course in _courses) if (course.Id == id) return course; return null; }
    public List<Course> GetAll() => _courses;
    public void Remove(int id) { var course = GetById(id); if (course is not null) _courses.Remove(course); }
}
