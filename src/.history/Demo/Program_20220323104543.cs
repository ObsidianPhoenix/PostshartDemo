using System;
using PostSharp.Patterns.Model;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = Test();
            student.OnPropertyChanged() += (sender, e) =>
            {
                Console.WriteLine("Property changed: {0}", e.PropertyName);
            };

            student.Name = "Fergal";

        }

        static void Test()
        {
            var student = new Student();
            student.Name = "John";
            student.Age = 20;
            student.Address = "London";
            student.Phone = "123456789";
            student.Email = "";

            return student;
        }
    }

    [NotifyPropertyChanged]
    public class Student
    {
        public string Name { get; set; }
    }
}
