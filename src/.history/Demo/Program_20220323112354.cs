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
            student.ResetDirty();
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

    [NotifyPropertyChanged]
    public abstract class Base
    {
        public bool IsDirty { get; private set;}

        public DatabaseStatus RecordStatus { get; private set; }

        protected Base()
        {
            ((INotifyPropertyChanged)this).PropertyChanged += OnPropertyChanged;
            RecordStatus = New;
        }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IsDirty))
            {
                IsDirty = true;

                if (RecordStatus == New)
                {
                    RecordStatus = Modified;
                }
            }
        }

        public void ResetDirty() => IsDirty = false;

        public void UpdateDatabaseStatus(DatabaseStatus status)
        {
            RecordStatus = status;
        }
    }

    public enum DatabaseStatus
    {
        New,
        Saved,
        Modified
    }

    
    public class Student : Base
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Student(string name, int age, string address, string phone, string email)
        : base()
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
        }
    }
}
