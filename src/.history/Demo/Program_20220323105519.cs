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
            ((INotifyPropertyChanged)student).PropertyChanged += (sender, e) =>
            {
                Console.WriteLine("Property changed: {0}", e.PropertyName);
            };

            student.Name = "Fergal";
            student.Email = "fergal.reilly@bedegaming.com";

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

        public bool IsDirty { get; private set;}

        public Student()
        {
            ((INotifyPropertyChanged)this) += OnPropertyChanged;
        }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!IsDirty)
            {
                IsDirty = true;
            }
        }
    }
}
