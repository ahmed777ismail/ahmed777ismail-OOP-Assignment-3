using Assignment.Generics;
var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Mona" });
Console.WriteLine(students.GetById(1)?.Name);
