using Microsoft.VisualBasic.FileIO;
using System;

namespace Sharma03
{
    public class Student
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronym { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Date { get; set; }
        public string Index { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public int Progress { get; set; }

        public Student() { }

        public Student(string name, string lastname, string patronym, DateTime birthday, DateTime date, string index, string faculty, string specialty, int progress)
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
            return $" Имя: {Name}\n Фамилия: {Lastname}\n Отчество: {Patronym}\n День рождения: {Birthday}\n Дата поступления: {Date}\n Индекс группы: {Index}\n Факультет: {Faculty}\n Специальность: {Specialty}\n Успеваемость: {Progress}\n \n";
        }
    }
}
