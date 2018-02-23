using System;

namespace Contacts
{
    class UI
    {
        private Directory directory = new Directory();

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                // display menu
                // accept menu selection 

                int choice = DisplayMenuAndGetChoice();
                switch (choice)
                {
                    case 1:
                        CreateContact();                        
                        break;
                    case 2:
                        ListContacts();
                        break;
                    case 3:
                        Console.WriteLine("Update");
                        break;
                    case 4:
                        Console.WriteLine("Destroy");
                        break;
                    default:
                        isRunning = false;
                        Console.WriteLine("BYE");
                        break;                       
                }

                // based on choice - add, list 
                //something should quit 
            }
        }

        private void ListContacts()
        {
            Console.WriteLine("List Contacts.");
            Contact[] contacts = directory.GetAll();
            if (contacts == null || contacts.Length == 0)
            {
                Console.WriteLine("No Contact Found.");
            }
            else
            {
                for (int i = 0; i < contacts.Length; i++)
                {
                    Contact c = contacts[i];
                    Console.WriteLine(c.GetFullName());
                    Console.WriteLine(c.Phone);
                    Console.WriteLine(c.Email);
                    Console.WriteLine("====================");
                }
            }
        }

        private string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private void CreateContact()
        {
            Contact c = new Contact();
            Console.WriteLine("Create contact:");

            c.FirstName = ReadString("Enter First Name:");
            c.LastName = ReadString("Enter Last Name:");
            c.Email = ReadString("Enter Email:");
            c.Phone = ReadString("Enter Phone:");

            directory.Save(c); //this saves our contacts 



            ////this is the bad way
            //Console.WriteLine("Enter Last Name");
            //c.FirstName = Console.ReadLine();
            //Console.WriteLine("Enter Last Name");
            //c.LastName = Console.ReadLine();
        }

        private int DisplayMenuAndGetChoice()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine(" 1. Add Contact");
            Console.WriteLine(" 2. list Contact");
            Console.WriteLine(" 3. Update Contact");
            Console.WriteLine(" 4. Delete Contact");
            Console.WriteLine(" Any other selection exists. ");

            int choice = 0;
            do
            {
                Console.WriteLine("Your Choice:");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Enter a valid selection.");
                }

            } while (choice <= 0);

            return choice;
        }
    }
}
