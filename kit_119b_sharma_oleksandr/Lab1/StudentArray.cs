using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNetLab1
{
    class StudentArray : System.Collections.IEnumerable
    {
        public Student[] students { get; set; }
        public bool empty { get; set; } = false;

        public void AddStudent(Student student)
        {
            if (students == null)
            {
                students = new Student[0];
            }

            var newArr = new Student[students.Length + 1];

            for (int i = 0, length = students.Length; i < length; i++)
            {
                newArr[i] = students[i];
            }

            newArr[students.Length] = student;
            students = newArr;

            if (!empty && students.Length > 0)
            {
                empty = true;
            }
        }

        public void DeleteStudentByIndex(int index)
        {
            if (students != null)
            {
                if (checkIndex(index))
                {
                    Student[] newArr = new Student[students.Length - 1];
                    for (int i = 0; i < index; i++)
                    {
                        newArr[i] = students[i];
                    }

                    for (int i = index + 1, length = students.Length; i < length; i++)
                    {
                        newArr[i] = students[i];
                    }

                    students = newArr;
                    if (empty && students.Length == 0) empty = false;

                }
                else
                {
                    Console.WriteLine("Index out of range");
                }
            }
            else
            {
                Console.WriteLine("Array is empty");
            }
        }


        private bool checkIndex(int index)
        {
            return index >= 0 && index <= students.Length - 1;
        }


        public void printStudents()
        {
            if (students != null)
            {
                int i = 0;
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Array is empty");
            }

        }

        public void findStudent(int index) {
            Console.WriteLine("Found a student!");
            Console.WriteLine(students[index].ToString());
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public StudentsEnum GetEnumerator()
        {
            return new StudentsEnum(students);
        }


}

    internal class StudentsEnum : IEnumerator
    {
        private Student[] students;
        int position = -1;

        public StudentsEnum(Student[] students)
        {
            this.students = students;
        }

        public bool MoveNext()
        {
            position++;
            return (position < students.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Student Current
        {
            get
            {
                try
                {
                    return students[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }


}
