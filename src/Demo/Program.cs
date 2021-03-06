using System;
using PostSharp.Patterns.Model;
using System.ComponentModel;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = CreateStudent();

            OutputStatus(student);
            student.Name = "Fergal";
            OutputStatus(student);
            student.Email = "fergal.reilly@bedegaming.com";
            OutputStatus(student);
            student.ResetDirty();
            OutputStatus(student);
            student.SetDatabaseStatus( DatabaseStatus.Saved);
            OutputStatus(student);
            student.Age = 39;
            OutputStatus(student);

        }

        public static void OutputStatus(Student student)
        {
            Console.WriteLine($"IsDirty: {student.IsDirty}, Database Status: {student.RecordStatus}");
        }

        static Student CreateStudent()
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
}
