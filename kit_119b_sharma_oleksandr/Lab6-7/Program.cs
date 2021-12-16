using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Sharma07
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\{Dean}\source\repos\SharmaSLN\Sharma07\saved.txt";
            StringBuilder sb = new StringBuilder();
            var records = new Container();
            bool loop = true;
            int number;
            int choice;

            while (loop)
            {
                Console.WriteLine("Что Вы хотите сделать?\n 1 - Добавить данные про студента\n 2 - Вывести на экран данные\n 3 - Записать данные в файл" +
                    "\n 4 - Прочитать данные из файла\n 5 - Найти элемент по индексу\n 6 - Удалить данные о студенте\n 7 - Редактировать данные студента" +
                    "\n 8 - Вывести название группы студента\n 9 - Вывести текущий курс и семестр студента\n 10 - Вывести текущий возраст студента" +
                    "\n 11 - Возраст студентов факультета\n 12 - Группы студентов факультета\n 13 - Курс студентов факультета\n 14 - Вывести студентов старше 20 лет" +
                    "\n 15 - Найти минимальный возраст студента на факультете \n 16 - Выход");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Helper.AddStud(records);
                        break;
                    case 2:
                        foreach (var student in records)
                        {
                            Console.WriteLine(student + " ");
                        }
                        break;
                    case 3:
                        Helper.WriteFile(records, path);
                        break;
                    case 4:
                        Helper.ReadFile(records, path);
                        break;
                    case 5:
                        Console.WriteLine("Номер студента, которого хотите найти: ");
                        number = int.Parse(Console.ReadLine());
                        records.Search(records, number);
                        break;
                    case 6:
                        Console.WriteLine("Номер студента, данные о котором хотите удалить: ");
                        number = int.Parse(Console.ReadLine());
                        records.Remove(records, number);
                        break;
                    case 7:
                        Console.WriteLine("Номер студента, данные о котором хотите отредактировать: ");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Что хотите отредактировать? (1-имя, 2 - фамилию, 3 - отчество, 4 - день рождения, 5 - дата поступления, " +
                                        "6 - индекс группы, 7 - факультет, 8 - специальность, 9 - успеваемость");
                        int n;
                        string str;
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новые данные в соответствующем формате : ");
                        str = Console.ReadLine();
                        records.Edit(records, number, n, str);
                        break;
                    case 8:
                        Console.WriteLine("Номер студента, чью группу хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        Helper.Group(records, number);
                        break;
                    case 9:
                        Console.WriteLine("Номер студента, чей номер курса и семестра на текущий момент хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        Helper.Course(records, number);
                        break;
                    case 10:
                        Console.WriteLine("Номер студента, чей текущий возраст хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        DateTime today = DateTime.Today;
                        DateTime b = records.students[number - 1].Birthday;

                        TimeSpan old = today.Subtract(b);
                        var d = new DateTime(old.Ticks);
                        Console.WriteLine($"Возраст: {d.Year - 1} лет, {d.Month - 1} месяцев, {d.Day - 1} дней");
                        break;
                    case 11:
                        Console.WriteLine("Введите факультет, возраст студентов которого хотите узнать: ");
                        string str3 = Console.ReadLine();

                        var selectedItems = from t in records.students
                                            where t.Faculty.Equals(str3)
                                            select t.Birthday.Year;
                        Console.WriteLine("Возраст студентов: ");
                        foreach (int y in selectedItems)
                            Console.Write(y + "  ");
                        Console.WriteLine();
                        break;
                    case 12:
                        Console.WriteLine("Введите факультет, названия групп студентов которого хотите узнать: ");
                        string str4 = Console.ReadLine();
                        var selectedItems1 = from t in records.students
                                             where t.Faculty.Equals(str4)
                                             select t.Faculty + t.Specialty + "-" + t.Date.Year + t.Index;

                        Console.WriteLine("Группы студентов: ");
                        foreach (string s in selectedItems1)
                            Console.Write(s + "  ");
                        Console.WriteLine();
                        break;
                    case 13:
                        Console.WriteLine("Введите факультет, номер курса студентов которого хотите узнать: ");
                        string str5 = Console.ReadLine();

                        List<int> selectedItems2 =
                            (from t in records.students
                             where t.Faculty.Equals(str5)
                             select DateTime.Today.Year - t.Date.Year).ToList();

                        Console.WriteLine("Курс студентов: ");
                        foreach (int s in selectedItems2)
                            Console.Write(s + "  ");
                        Console.WriteLine();
                        break;
                    case 14:
                        var selectedStud = records.students.Where(student => student.Age(student) >= 20);
                        foreach (Student stud in selectedStud)
                            Console.WriteLine($"{stud.Name} {stud.Lastname} - {stud.Age(stud)}");
                        break;
                    case 15:
                        Console.WriteLine("Введите факультет, минимальный возраст студентов которого хотите узнать: ");
                        string str6 = Console.ReadLine();
                        var selectedStud1 = (from t in records.students
                                             where t.Faculty.Equals(str6)
                                             select t.Age(t)).Min();
                        Console.WriteLine($"Минимальный возраст студента: {selectedStud1}");
                        break;
                    case 16:
                        loop = false;
                        break;
                }
            }
        }
    }
}
