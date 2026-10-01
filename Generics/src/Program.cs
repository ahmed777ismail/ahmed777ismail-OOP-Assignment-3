using Assignment.Generics;

var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Mona" });
students.Add(new Student { Id = 2, Name = "Omar" });
students.Add(new Student { Id = 3, Name = "Nour" });
students.Add(new Student { Id = 4, Name = "Youssef" });
students.Add(new Student { Id = 5, Name = "Salma" });

var courses = new Store<Course>();
courses.Add(new Course { Id = 101, Title = "C#", Price = 1200m });
courses.Add(new Course { Id = 102, Title = "OOP", Price = 1500m });
courses.Add(new Course { Id = 103, Title = "Databases", Price = 1000m });

Console.WriteLine($"Student by ID: {students.GetById(3)?.Name}");
Console.WriteLine($"Course by ID: {courses.GetById(102)?.Title}");

try { students.Add(new Student { Id = 3, Name = "Duplicate" }); }
catch (InvalidOperationException exception) { Console.WriteLine(exception.Message); }

Console.WriteLine("Students page 2 (size 2):");
foreach (var student in students.GetAll().Page(2, 2)) Console.WriteLine($"{student.Id}: {student.Name}");

var courseList = new List<Course> { new() { Id = 201, Title = "Algorithms", Price = 900m }, new() { Id = 202, Title = "APIs", Price = 1100m } };
Console.WriteLine($"List course by ID: {courseList.FindById(202)?.Title}");
var byId = courseList.ToIdDictionary();
Console.WriteLine($"Dictionary lookup: {byId[201].Title}");

// var invalidStore = new Store<string>(); // must NOT compile
