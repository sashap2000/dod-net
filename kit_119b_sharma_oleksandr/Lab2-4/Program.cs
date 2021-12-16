using System;
using System.IO;
using System.Text;

namespace Sharma03
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var studArr = new StudentArray();
            bool flag = true;
            string name, lastname, patronym, faculty, specialty;
            string path = @"C:\Users\{Dean}\source\repos\Sharma03\Sharma03\saved.txt";
            DateTime birthday, date;
            int progress, number;
            string index;
            string text;
            int choice;
            while (flag)
            {
                Console.WriteLine("Что Вы хотите сделать?\n 1 - Добавить данные про студента\n 2 - Вывести на экран данные\n 3 - Записать данные в файл" +
                    "\n 4 - Прочитать данные из файла\n 5 - Найти элемент по индексу\n 6 - Удалить данные о студенте\n 7 - Редактировать данные студента" +
                    "\n 8 - Вывести название группы студента\n 9 - Вывести текущий курс и семестр студента\n 10 - Вывести текущий возраст студента\n" +
                    "11 - Выход");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        name = Input.EnterName("Имя");
                        lastname = Input.EnterName("Фамилию");
                        patronym = Input.EnterName("Отчество");
                        birthday = Input.EnterDate("День рождения");
                        date = Input.EnterDate("Дату поступления");
                        index = Input.EnterUniInfo("Индекс группы");
                        faculty = Input.EnterUniInfo("Факультет");
                        specialty = Input.EnterUniInfo("Специальность");
                        progress = Input.EnterPercents("Успеваемость");
                        var stud = new Student(name, lastname, patronym, birthday, date, index, faculty, specialty, progress);
                        studArr.Add(stud);
                        break;
                    case 2:
                        foreach (var student in studArr)
                        {
                            Console.WriteLine(student + " ");
                        }
                        break;
                    case 3:
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                            {
                                sw.WriteLine("Студенты: ");
                            }
                            foreach (var student in studArr)
                            {
                                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                                {
                                    sw.WriteLine(student);
                                }
                            }
                            Console.WriteLine("Запись выполнена");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
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
                                    index = words[9 * i + 5];
                                    faculty = words[9 * i + 6];
                                    specialty = words[9 * i + 7];
                                    progress = int.Parse(words[9 * i + 8]);
                                    stud = new Student(name, lastname, patronym, birthday, date, index, faculty, specialty, progress);
                                    studArr.Add(stud);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Номер студента, которого хотите найти: ");
                        number = int.Parse(Console.ReadLine());
                        studArr.Search(studArr, number);
                        break;
                    case 6:
                        Console.WriteLine("Номер студента, данные о котором хотите удалить: ");
                        number = int.Parse(Console.ReadLine());
                        studArr.Remove(studArr, number);
                        break;
                    case 7:
                        Console.WriteLine("Номер студента, данные о котором хотите отредактировать: ");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Что хотите отредактировать? (1-имя, 2 - фамилию, 3 - отчество, 4 - день рождения, 5 - дата поступления, " +
                                        "6 - индекс группы, 7 - факультет, 8 - специальность, 9 - успеваемость");
                        int n;
                        n = int.Parse(Console.ReadLine());
                        switch (n)
                        {
                            case 1:
                                studArr.Edit(studArr, number, "name");
                                break;
                            case 2:
                                studArr.Edit(studArr, number, "lastname");
                                break;
                            case 3:
                                studArr.Edit(studArr, number, "patronym");
                                break;
                            case 4:
                                studArr.Edit(studArr, number, "birthday");
                                break;
                            case 5:
                                studArr.Edit(studArr, number, "date");
                                break;
                            case 6:
                                studArr.Edit(studArr, number, "index");
                                break;
                            case 7:
                                studArr.Edit(studArr, number, "faculty");
                                break;
                            case 8:
                                studArr.Edit(studArr, number, "specialty");
                                break;
                            case 9:
                                studArr.Edit(studArr, number, "progress");
                                break;
                        }
                        break;
                    case 8:
                        Console.WriteLine("Номер студента, чью группу хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        sb.Append(studArr.students[number - 1].Faculty);
                        sb.Append(studArr.students[number - 1].Specialty);
                        sb.Append("-");
                        sb.Append(studArr.students[number - 1].Date.Year);
                        sb.Append(studArr.students[number - 1].Index);
                        sb.AppendLine();
                        Console.WriteLine(sb.ToString());
                        break;
                    case 9:
                        Console.WriteLine("Номер студента, чей номер курса и семестра на текущий момент хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        int course, semester;
                        course = DateTime.Today.Year - studArr.students[number - 1].Date.Year;
                        if (DateTime.Today.Month >= 7 && DateTime.Today.Month <= 12)
                        {
                            semester = course * 2 - 1;
                        }
                        else
                        {
                            semester = course * 2;
                        }
                        Console.WriteLine($"Курс : {course}, семестр : {semester}");
                        break;
                    case 10:
                        Console.WriteLine("Номер студента, чей текущий возраст хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        DateTime today = DateTime.Today;
                        DateTime b = studArr.students[number - 1].Birthday;
                        TimeSpan old = today.Subtract(b);
                        var d = new DateTime(old.Ticks);
                        /*int year = Convert.ToInt32(Math.Floor(old.TotalDays / 365));
                        int month = Convert.ToInt32(Math.Floor((old.TotalDays % 365) / 31));
                        int day = Convert.ToInt32(Math.Floor((old.TotalDays % 365) % 31));*/
                        Console.WriteLine($"Возраст: {d.Year - 1} лет, {d.Month - 1} месяцев, {d.Day - 1} дней");
                        break;
                    case 11:
                        flag = false;
                        break;
                }
            }
        }
    }
}


