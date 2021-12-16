using Lab5;
using System;
using System.IO;
using System.Text;

namespace Lab05
{
    class Helper
    {
        public static void AddStud(Container records)
        {
            string name, lastname, patronym, faculty;
            DateTime birthday, date;
            int progress, specialty;
            char index;
            Console.WriteLine("Имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Фамилия: ");
            lastname = Console.ReadLine();
            Console.WriteLine("Отчество: ");
            patronym = Console.ReadLine();
            Console.WriteLine("День рождения: ");
            birthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Дата поступления: ");
            date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Индекс группы: ");
            index = char.Parse(Console.ReadLine());
            Console.WriteLine("Факультет: ");
            faculty = Console.ReadLine();
            Console.WriteLine("Специальность: ");
            specialty = int.Parse(Console.ReadLine());
            Console.WriteLine("Успеваемость: ");
            progress = int.Parse(Console.ReadLine());
            var stud = new Student(name, lastname, patronym, birthday, date, index, faculty, specialty, progress);
            records.Add(stud);
        }

        public static void ReadFile(Container records, string path)
        {
            string name, lastname, patronym, faculty, text;
            DateTime birthday, date;
            int progress, specialty;
            char index;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();

                    string[] separatingStrings = { " ", "\r", "\n", ":", "00:00:00", "\t", "Студенты", "Имя", "Фамилия", "Отчество", "День рождения",
                                    "Дата поступления", "Индекс группы", "Факультет", "Специальность", "Успеваемость"};
                    string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length / 9; i++)
                    {
                        name = words[9 * i];
                        lastname = words[9 * i + 1];
                        patronym = words[9 * i + 2];
                        birthday = DateTime.Parse(words[9 * i + 3]);
                        date = DateTime.Parse(words[9 * i + 4]);
                        index = char.Parse(words[9 * i + 5]);
                        faculty = words[9 * i + 6];
                        specialty = int.Parse(words[9 * i + 7]);
                        progress = int.Parse(words[9 * i + 8]);
                        var stud = new Student(name, lastname, patronym, birthday, date, index, faculty, specialty, progress);
                        records.Add(stud);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteFile(Container records, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Студенты: ");
                }
                foreach (var student in records)
                {
                    using StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    sw.WriteLine(student);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Course(Container records, int number)
        {
            int course, semester;
            course = DateTime.Today.Year - records.students[number - 1].Date.Year;
            if (DateTime.Today.Month >= 7 && DateTime.Today.Month <= 12)
            {
                semester = course * 2 - 1;
            }
            else
            {
                semester = course * 2;
            }
            Console.WriteLine($"Курс : {course}, семестр : {semester}");
        }

        public static void Group(Container records, int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(records.students[number - 1].Faculty);
            sb.Append(records.students[number - 1].Specialty);
            sb.Append("-");
            sb.Append(records.students[number - 1].Date.Year);
            sb.Append(records.students[number - 1].Index);
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
}
