using Assignment.Generics;
var students = new StudentStore();
students.Add(new Student { Id = 1, Name = "Mona" });
Console.WriteLine(students.GetById(1)?.Name);
