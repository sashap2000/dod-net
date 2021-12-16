using System;

namespace WebApplication1
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronym { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Date { get; set; }
        public char Index { get; set; }
        public string Faculty { get; set; }
        public int Specialty { get; set; }
        public int Progress { get; set; }

        public Student() { }

        public Student(string name, string lastname, string patronym, DateTime birthday, DateTime date, char index, string faculty, int specialty, int progress)
        {
            this.Name = name;
            this.Lastname = lastname;
            this.Patronym = patronym;
            this.Birthday = birthday;
            this.Date = date;
            this.Index = index;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.Progress = progress;
        }

        public override string ToString()
        {
            return $"{Name}\t {Lastname}\t {Patronym}\t {Birthday}\t {Date}\t {Index}\t {Faculty}\t {Specialty}\t {Progress} \n";
        }

        public int Age(Student stud)
        {
            int year = stud.Birthday.Year;
            int age = DateTime.Now.Year - year;
            return age;
        }
    }
}