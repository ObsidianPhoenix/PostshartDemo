using System;
using PostSharp.Patterns.Models;

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

        }

        static void Test()
        {
            var student = new Student();
            student.Name = "John";
            student.Age = 20;
            student.Address = "London";
            student.Phone = "123456789";
            student.Email = "";
        }

    public class Student
    {
        [NotifyPropertyChanged]
        public string Name { get; set; }
    }
}
