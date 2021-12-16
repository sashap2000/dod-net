using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sharma03
{
    public class StudentArray : IEnumerable, IEnumerator
    {
        static int size = 1;
        public Student[] students = new Student[size];
        //Student[] students2 = new Student[size];
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

        public void Search(StudentArray records, int number)
        {
            Console.WriteLine("Студент по индексу :");
            Console.Write(records.students[number - 1] + " ");
        }

        public void Remove(StudentArray records, int number)
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

        public void Edit(StudentArray records, int number, string s)
        {
            switch (s)
            {
                case "name":
                    records.students[number - 1].Name = Input.EnterName("Введите имя");
                    break;
                case "lastname":
                    records.students[number - 1].Lastname = Input.EnterName("Введите фамилию");
                    break;
                case "patronym":
                    records.students[number - 1].Patronym = Input.EnterName("Введите отчество");
                    break;
                case "birthday":
                    records.students[number - 1].Birthday = Input.EnterDate("Введите новую дату рождения");
                    break;
                case "date":
                    records.students[number - 1].Date = Input.EnterDate("Введите новую дату поступления");
                    break;
                case "index":
                    records.students[number - 1].Index = Input.EnterUniInfo("Введите индекс группы");
                    break;
                case "faculty":
                    records.students[number - 1].Faculty = Input.EnterUniInfo("Введите индекс группы");
                    break;
                case "specialty":
                    records.students[number - 1].Specialty = Input.EnterUniInfo("Введите специальность");
                    break;
                case "progress":
                    records.students[number - 1].Progress = Input.EnterPercents("Введите академ.успеваемость в процентах");
                    break;
            }

            Console.WriteLine("Измененный список студентов :");
            foreach (var student in records)
            {
                Console.WriteLine(student + " ");
            }
        }
    }
}
