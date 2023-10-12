using static System.Console;
using System.Collections.Generic;
using System.Net;

class Program
{

    #region Teachers

    static List<Teacher> TeachersList = new List<Teacher>();
    static void AddTeacher()
    {
        Write("Enter name: ");
        string name = Console.ReadLine();
        Write("Enter payroll: ");
        string payroll = Console.ReadLine();
        Write("Enter password: ");
        string password = Console.ReadLine();
        Write("Enter subject: ");
        string subject = Console.ReadLine();
        Write("Enter division: ");
        string division = Console.ReadLine();
        Teacher teacher = new Teacher(name, payroll, password, subject, division);
        TeachersList.Add(teacher);

        WriteLine("Teacher added successfully");
    }

    static void EditTeacher()
    {
        Write("ID of the teacher to edit: ");
        int ID = Convert.ToInt32(ReadLine());
        if(ID >= 0 && ID < TeachersList.Count)
        {
            Teacher teacher = TeachersList[ID];
            Write("Enter name: ");
            string name = Console.ReadLine();
            Write("Enter payroll: ");
            string payroll = Console.ReadLine();
            Write("Enter password: ");
            string password = Console.ReadLine();
            Write("Enter subject: ");
            string subject = Console.ReadLine();
            Write("Enter division: ");
            string division = Console.ReadLine();
            teacher.Name = name;
            teacher.Payroll = payroll;
            teacher.Password = password;
            teacher.Subject = subject;
            teacher.Division = division;
            TeachersList[ID] = teacher;
        }
        WriteLine("Teacher updated successfully");
    }

    static void DeleteTeacher()
    {
        Write("ID of the teacher to delete: ");
        int ID = Convert.ToInt32(ReadLine());
        if(ID >= 0 && ID < TeachersList.Count)
        {
            TeachersList.RemoveAt(ID);
        }
        WriteLine("Teacher deleted successfully");
    }

    #endregion


    #region Passwords
    static void ChangePasswordsSubMenu() 
    {
        while(true)
        {
            WriteLine("\nPassword Menu:");
            WriteLine("1. Change Teacher Password");
            WriteLine("2. Change StoreKeeper Password");
            WriteLine("3. Exit");

            int choice = Convert.ToInt32(ReadLine());
            switch(choice)
            {
                case 1:
                    WriteLine("Change Teacher Password");
                    break;
                case 2:
                    WriteLine("Change StoreKeeper Password");
                    break;
                case 3:
                    WriteLine("Exit");
                    break;
                default:
                    WriteLine("Invalid choice");
                    break;
            }
        }
    }

    #endregion
    static void Main()
    {
        while(true) 
        {
            WriteLine("\nMenu:");
            WriteLine("1. Login");
            WriteLine("2. Add Teacher");
            WriteLine("3. Edit Teacher");
            WriteLine("4. Delete Teacher");
            WriteLine("5. Change Password");
            WriteLine("6. Report");
            WriteLine("6. Exit");
            Write("Enter your choice: ");
            string choice = ReadLine();
            switch(choice)
            {
                case "1":
                    WriteLine("Login");
                    break;
                case "2":
                    WriteLine("Add Teacher");
                    AddTeacher();
                    break;
                case "3":
                    WriteLine("Edit Teacher");
                    EditTeacher();
                    break;
                case "4":
                    WriteLine("Delete Teacher");

                    break;
                case "5":
                    WriteLine("Change Password");

                    break;
                case "6":
                    WriteLine("Report");
                    break;
                case "7":
                    WriteLine("Exit");
                    break;
                default:
                    WriteLine("Invalid choice");
                    break;
            }  

        }

    }
}
