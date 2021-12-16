using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLab1
{
    class Mainmenu
    {
        public static void Start()
        {
            var studentArray = new StudentArray();
            while (true)
            {
                PrintMainMenu();
                int choice;
                try
                {
                    choice = Input.EnterInt("choice");
                    switch (choice)
                    {
                        case 1:
                            {
                                studentArray.AddStudent(CreateStudent());
                                break;
                            }
                        case 2:
                            {
                                studentArray.printStudents();
                                studentArray.DeleteStudentByIndex(Input.EnterInt("index"));
                                break;
                            }
                        case 3:
                            {
                                studentArray.printStudents();
                                break;
                            }
                        case 4:
                            {
                                int searchChoice = Input.EnterInt("index");
                                studentArray.findStudent(searchChoice);
                                break;
                            }
                        case 0:
                            {
                                return;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            }
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. Print list of students");
            Console.WriteLine("3. Find a student");
            Console.WriteLine("0. Exit");
        }

        public static Student CreateStudent()
        {
            string surname = Input.EnterName("student's surname");
            string name = Input.EnterName("student's name");
            string patronymic = Input.EnterName("student's patronymic");
            DateTime dob = Input.EnterDate("day of birth");
            DateTime enterDate = Input.EnterDate("acquiring date");
            string groupIndex = Input.EnterString("group index");
            string faculty = Input.EnterUniInfo("faculty");
            string specialty = Input.EnterUniInfo("speciality");
            int academicPerformance = Input.EnterPercents("academic performance, in percents");
            return new Student(surname, name, patronymic, dob, enterDate, groupIndex, faculty, specialty, academicPerformance);
        }

    }
}
