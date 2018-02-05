﻿using StudentManagementSystem.Helpers;
using StudentManagementSystem.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class MainMenu
    {
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add  Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit ");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("");
            Console.Write("Enter Choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("List students");
                    ListStudentWorkflow listWorkflow = new ListStudentWorkflow();
                    listWorkflow.Execute();
                    break;
                case "2":
                    Console.WriteLine("Add student");
                    AddStudentWorkflow addWorkflow = new AddStudentWorkflow();
                    addWorkflow.Execute();
                    break;
                case "3":
                    Console.WriteLine("Remove student");
                    RemoveStudentWorkflow removeWorkflow = new RemoveStudentWorkflow();
                    removeWorkflow.Execute();
                    break;
                case "4":
                    Console.WriteLine("Edit student");
                    EditStudentWorkflow editWorkflow = new EditStudentWorkflow();
                    editWorkflow.Execute();
                    break;
                case "Q":
                    return false; //will make us leave the method 
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }

            return true;
        }

        public static void Show()
        {
            bool continueRunning = true; 
            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }
    }
}
