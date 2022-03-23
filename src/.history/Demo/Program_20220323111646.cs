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

            Console.WriteLine(student.IsDirty);
            student.Name = "Fergal";
            Console.WriteLine(student.IsDirty);
            student.Email = "fergal.reilly@bedegaming.com";
            Console.WriteLine(student.IsDirty);

        }

        static Student Test()
        {
            var student = new Student(
                "Fergal",
                31,
                "",
                "",
                ""
            );


            student.ResetDirty();

            return student;
        }
    }

    public abstract class Base
    {
        public bool IsDirty { get; private set;}

        protected Base()
        {
            ((INotifyPropertyChanged)this).PropertyChanged += OnPropertyChanged;
        }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IsDirty))
            {
                IsDirty = true;
            }
        }

        public void ResetDirty() => IsDirty = false;
    }

    [NotifyPropertyChanged]
    public class Student : Base
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        

        public Student(string Name, int Age, string Address, string Phone, string Email)
        : this()
        {
            this.Name = Name;
            this.Age = Age;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
        }

        
    }
}
