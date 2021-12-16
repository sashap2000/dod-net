using System;
using System.Collections;
using System.Text;

namespace Lab5
{
    public class Container : IEnumerable, IEnumerator
    {
        static int size = 1;
        public Student[] students = new Student[size];
        int index = -1;
        int currentSize = 0;

        // Реализуем интерфейс IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // Реализуем интерфейс IEnumerator
        public bool MoveNext()
        {
            if (index == students.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return students[index];
            }
        }

        public void Add(Student student)
        {
            currentSize = NewSize();
            if (currentSize < size)
            {
                students[currentSize] = student;
            }

            else
            {
                size = currentSize + 1;
                Array.Resize(ref students, size);
                students[size - 1] = student;
            }
        }

        int NewSize()
        {
            currentSize = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                    currentSize++;
            }
            return currentSize;
        }

        public void Search(Container records, int number)
        {
            Console.WriteLine("Студент по индексу :");
            Console.Write(records.students[number - 1] + " ");
        }

        public void Remove(Container records, int number)
        {
            currentSize = NewSize();
            students[number - 1] = null;
            size--;
            for (int i = number; i < currentSize; i++)
            {
                if (students[i] != null)
                {
                    students[i - 1] = students[i];
                }
            }
            Array.Resize(ref students, currentSize - 1);
        }

        public void Edit(Container records, int number, int n, string str)
        {
            switch (n)
            {
                case 1:
                    records.students[number - 1].Name = str;
                    break;
                case 2:
                    records.students[number - 1].Lastname = str;
                    break;
                case 3:
                    records.students[number - 1].Patronym = str;
                    break;
                case 4:
                    records.students[number - 1].Birthday = DateTime.Parse(str);
                    break;
                case 5:
                    records.students[number - 1].Date = DateTime.Parse(str);
                    break;
                case 6:
                    records.students[number - 1].Index = char.Parse(str);
                    break;
                case 7:
                    records.students[number - 1].Faculty = str;
                    break;
                case 8:
                    records.students[number - 1].Specialty = int.Parse(str);
                    break;
                case 9:
                    records.students[number - 1].Progress = int.Parse(str);
                    break;
            }

            Console.WriteLine("Измененный список студентов :");
            foreach (var student in records)
            {
                Console.WriteLine(student + " ");
            }
        }

        public string Group(Container records, int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(records.students[number - 1].Faculty);
            sb.Append(records.students[number - 1].Specialty);
            sb.Append("-");
            sb.Append(records.students[number - 1].Date.Year);
            sb.Append(records.students[number - 1].Index);
            sb.AppendLine();
            return sb.ToString();
        }

        public void GrRemove(Container records, int number, String str)
        {
            switch (number)
            {
                case 1:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (Group(records, i + 1).Equals(str + "\r\n"))
                        {
                            records.Remove(records, i + 1);
                        }
                    }
                    break;
                case 2:
                    int spec = int.Parse(str);
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Specialty.Equals(spec))
                        {
                            records.Remove(records, i + 1);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Faculty.Equals(str))
                        {
                            records.Remove(records, i + 1);
                            i--;
                        }
                    }
                    break;
            }
        }

        public void Print(Container records, int number, String str)
        {
            switch (number)
            {
                case 1:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (Group(records, i + 1).Equals(str + "\r\n"))
                        {
                            Console.WriteLine(records.students[i]);
                        }
                    }
                    break;
                case 2:
                    int spec = int.Parse(str);
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Specialty.Equals(spec))
                        {
                            Console.WriteLine(records.students[i]);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Faculty.Equals(str))
                        {
                            Console.WriteLine(records.students[i]);
                        }
                    }
                    break;
            }
        }

        public int AvAge(Container records, int number, String str)
        {
            int count = 0, age = 0, av;
            DateTime today = DateTime.Today;
            DateTime b;
            switch (number)
            {
                case 1:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (Group(records, i + 1).Equals(str + "\r\n"))
                        {
                            b = records.students[i].Birthday;
                            TimeSpan old = today.Subtract(b);
                            var d = new DateTime(old.Ticks);
                            count++;
                            age += d.Year;
                        }
                    }
                    break;
                case 2:
                    int spec = int.Parse(str);
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Specialty.Equals(spec))
                        {
                            b = records.students[i].Birthday;
                            TimeSpan old = today.Subtract(b);
                            var d = new DateTime(old.Ticks);
                            count++;
                            age += d.Year;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Faculty.Equals(str))
                        {
                            b = records.students[i].Birthday;
                            TimeSpan old = today.Subtract(b);
                            var d = new DateTime(old.Ticks);
                            count++;
                            age += d.Year;
                        }
                    }
                    break;
            }
            av = age / count;
            return av;
        }

        public int AvProgress(Container records, int number, String str)
        {
            int count = 0, progress = 0, av;

            switch (number)
            {
                case 1:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (Group(records, i + 1).Equals(str + "\r\n"))
                        {
                            count++;
                            progress += records.students[i].Progress;
                        }
                    }
                    break;
                case 2:
                    int spec = int.Parse(str);
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Specialty.Equals(spec))
                        {
                            count++;
                            progress += records.students[i].Progress;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].Faculty.Equals(str))
                        {
                            count++;
                            progress += records.students[i].Progress;
                        }
                    }
                    break;
            }
            av = progress / count;
            return av;
        }
    }
}
