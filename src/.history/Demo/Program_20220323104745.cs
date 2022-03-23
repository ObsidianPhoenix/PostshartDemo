using System;
using PostSharp.Patterns.Model;
using System.ComponentModel;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = Test();
            ((INotifyPropertyChanged)student).OnPropertyChanged() += (sender, e) =>
            {
                Console.WriteLine("Property changed: {0}", e.PropertyName);
            };

            student.Name = "Fergal";

        }

        static Student Test()
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
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
