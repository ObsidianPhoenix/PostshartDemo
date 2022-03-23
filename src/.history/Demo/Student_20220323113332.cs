namespace Demo
{
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
