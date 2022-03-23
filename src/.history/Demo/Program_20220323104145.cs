using System;
using PostSharp.Patterns.Models;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Student
    {
        [NotifyPropertyChanged]
        public string Name { get; set; }
    }
}
