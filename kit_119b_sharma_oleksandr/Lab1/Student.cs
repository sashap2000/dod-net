using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLab1
{

    class Student
    {
        public string Surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime enterDate { get; set; }
        public string groupIndex { get; set; }
        public string faculty { get; set; }
        public string specialty { get; set; }
        public int academicPerformance { get; set; }

        public Student() { }

        public Student(string surname, string name, string patronymic, DateTime dob, DateTime enterDate, string groupIndex, string faculty, string specialty, int academicPerformance)
        {
            this.Surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            dateOfBirth = dob;
            this.enterDate = enterDate;
            this.groupIndex = groupIndex;
            this.faculty = faculty;
            this.specialty = specialty;
            this.academicPerformance = academicPerformance;
        }

        public override string ToString()
        {
          return  $"Surname: {Surname}\nName: {name}\nPatronymic: {patronymic}\nDate of birth: {dateOfBirth.ToString()}\nEnter date: {enterDate}\nGroup index: {groupIndex}\n" +
          $"Faculty: {faculty}\nSpecialty: {specialty}\nAcademic performance: {academicPerformance}\n";
               
  }
    }
}
