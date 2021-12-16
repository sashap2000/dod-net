﻿using System;
using System.Collections;

namespace Sharma07
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
            for (int i = number; i < currentSize; i++)
            {
                if (students[i] != null)
                {
                    students[i - 1] = students[i];
                }
            }
            Array.Resize(ref students, currentSize - 1);
            Console.WriteLine("Измененный список студентов :");
            foreach (var student in records)
            {
                Console.WriteLine(student + " ");
            }
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

        public int Age(Container records, int i)
        {
            int year = records.students[i].Birthday.Year;
            int age = DateTime.Now.Year - year;
            return age;
        }
    }
}
