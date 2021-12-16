using Lab05;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lab5
{
    class Program
    {
        delegate int Average(Container records, int number, String str);
        static void Main(string[] args)
        {
            string path = @"C:\Users\{Dean}\source\repos\Lab5\Lab5\save.txt";
            StringBuilder sb = new StringBuilder();
            var studArr = new Container();
            bool flag = true;
            int number;
            int choice;
            Average average;

            while (flag)
            {
                Console.WriteLine("Что Вы хотите сделать?\n 1 - Добавить данные про студента\n 2 - Вывести на экран данные\n 3 - Записать данные в файл" +
                    "\n 4 - Прочитать данные из файла\n 5 - Найти элемент по индексу\n 6 - Удалить данные о студенте\n 7 - Редактировать данные студента" +
                    "\n 8 - Вывести название группы студента\n 9 - Вывести текущий курс и семестр студента\n 10 - Вывести текущий возраст студента\n" +
                    " 11 - Вывести на экран данные о студентах(выбранной группы, специальности, факультета)\n 12 - Групповое удаление данных\n" +
                    " 13 - Средний возраст(выбранной группы, специальности, факультета)\n 14 - Средняя успеваемость(выбранной группы, специальности, факультета)\n" +
                    " 15 - Выход");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Helper.AddStud(studArr);
                        break;
                    case 2:
                        Console.WriteLine("Имя\t Фамилия\t Отчество\t Дата рождения\t\t Дата поступления     Индекс   Ф-тет  Спец-сть  Усп-сть");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        foreach (var student in studArr)
                        {
                            Console.WriteLine(student + " ");
                        }
                        break;
                    case 3:
                        Helper.WriteFile(studArr, path);
                        break;
                    case 4:
                        Helper.ReadFile(studArr, path);
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
                        string str;
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новые данные в соответствующем формате : ");
                        str = Console.ReadLine();
                        studArr.Edit(studArr, number, n, str);
                        break;
                    case 8:
                        Console.WriteLine("Номер студента, чью группу хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        Helper.Group(studArr, number);
                        break;
                    case 9:
                        Console.WriteLine("Номер студента, чей номер курса и семестра на текущий момент хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        Helper.Course(studArr, number);
                        break;
                    case 10:
                        Console.WriteLine("Номер студента, чей текущий возраст хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        DateTime today = DateTime.Today;
                        DateTime b = studArr.students[number - 1].Birthday;
                        TimeSpan old = today.Subtract(b);
                        var d = new DateTime(old.Ticks);
                        Console.WriteLine($"Возраст: {d.Year - 1} лет, {d.Month - 1} месяцев, {d.Day - 1} дней");
                        break;
                    case 11:
                        Console.WriteLine("По какому критерию вывести список студентов? (1 - группа, 2 - специальность, 3 - факультет)");
                        int num;
                        string str1;
                        num = int.Parse(Console.ReadLine());
                        switch (num)
                        {
                            case 1:
                                Console.WriteLine("Введите группу : ");
                                break;
                            case 2:
                                Console.WriteLine("Введите специальность : ");
                                break;
                            case 3:
                                Console.WriteLine("Введите факультет : ");
                                break;
                        }
                        str1 = Console.ReadLine();
                        studArr.Print(studArr, num, str1);
                        break;
                    case 12:
                        Console.WriteLine("По какому критерию удалить студентов? (1 - группа, 2 - специальность, 3 - факультет)");
                        int numb;
                        string str2;
                        numb = int.Parse(Console.ReadLine());
                        switch (numb)
                        {
                            case 1:
                                Console.WriteLine("Введите группу : ");
                                break;
                            case 2:
                                Console.WriteLine("Введите специальность : ");
                                break;
                            case 3:
                                Console.WriteLine("Введите факультет : ");
                                break;
                        }
                        str2 = Console.ReadLine();
                        studArr.GrRemove(studArr, numb, str2);
                        break;
                    case 13:
                        Console.WriteLine("По какому критерию средний возраст студентов? (1 - группа, 2 - специальность, 3 - факультет)");
                        int num2;
                        string str3;
                        num2 = int.Parse(Console.ReadLine());
                        switch (num2)
                        {
                            case 1:
                                Console.WriteLine("Введите группу : ");
                                break;
                            case 2:
                                Console.WriteLine("Введите специальность : ");
                                break;
                            case 3:
                                Console.WriteLine("Введите факультет : ");
                                break;
                        }
                        str3 = Console.ReadLine();
                        average = studArr.AvAge;
                        Console.WriteLine("Средний возраст: " + average(studArr, num2, str3));
                        break;
                    case 14:
                        Console.WriteLine("По какому критерию расчитать среднюю успеваемость студентов? (1 - группа, 2 - специальность, 3 - факультет)");
                        int num3;
                        string str4;
                        num3 = int.Parse(Console.ReadLine());
                        switch (num3)
                        {
                            case 1:
                                Console.WriteLine("Введите группу : ");
                                break;
                            case 2:
                                Console.WriteLine("Введите специальность : ");
                                break;
                            case 3:
                                Console.WriteLine("Введите факультет : ");
                                break;
                        }
                        str4 = Console.ReadLine();
                        average = studArr.AvProgress;
                        Console.WriteLine("Средняя успеваемость: " + average(studArr, num3, str4));
                        break;
                    case 15:
                        flag = false;
                        break;
                }
            }
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));

            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, studArr.students);
            }

            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                Student[] newStud = (Student[])formatter.Deserialize(fs);

                foreach (Student p in newStud)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
