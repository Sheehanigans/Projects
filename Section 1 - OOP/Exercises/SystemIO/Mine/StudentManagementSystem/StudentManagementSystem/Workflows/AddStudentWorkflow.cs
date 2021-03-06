﻿using StudentManagementSystem.Data;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Workflows
{
    public class AddStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add student");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            Student newStudent = new Student();

            newStudent.FirstName = ConsoleIO.GetRequiredStringFromUser("First name: ");
            newStudent.LastName = ConsoleIO.GetRequiredStringFromUser("Last name: ");
            newStudent.Major = ConsoleIO.GetRequiredStringFromUser("Major: ");
            newStudent.GPA = ConsoleIO.GetRequiredDecimalFromUser("GPA: ");

            Console.WriteLine();
            ConsoleIO.PrintstudentListHeader();
            Console.WriteLine(ConsoleIO.StudentLineFormat, newStudent.LastName + "," + newStudent.FirstName, newStudent.Major, newStudent.GPA);

            Console.WriteLine();

            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
                StudentRepository repo = new StudentRepository(Settings.FilePath);
                repo.Add(newStudent);
                Console.WriteLine("Student added!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Add cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

        }
    }
}
