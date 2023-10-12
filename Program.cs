using static System.Console;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Xml.Serialization;

public class Program
{
    #region Teachers
    static List<Teacher> TeachersList = new List<Teacher>();
    static void AddTeacher()
    {
        int HTeacherID = TeachersList.Any() ? TeachersList.Max(teacher => teacher.TeacherID) + 1 : 1;

        Write("Enter name: ");
        string name = Console.ReadLine();
        Write("Enter payroll: ");
        string payroll = Console.ReadLine();
        Write("Enter password: ");
        string password = Console.ReadLine();
        Write("Enter subject: ");
        string subjectinput = Console.ReadLine();
        string[] subject = subjectinput.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        Write("Enter division: ");
        string division = Console.ReadLine();
        Teacher teacher = new Teacher(HTeacherID, name, payroll, password, subject, division);
        TeachersList.Add(teacher);
        SerializeTeacherJSON();
        SerializeTeacherToXml();
        WriteLine("Teacher added successfully");
    }

    static void EditTeacher()
    {
        Write("ID of the teacher to edit: ");
        int ID = Convert.ToInt32(ReadLine());
        if(ID >= 1 && ID <= TeachersList.Count) // Verificamos que el ID sea válido
        {
        Teacher teacher = TeachersList[ID - 1]; // Ajustamos el índice

        WriteLine("Enter new name (or press enter to keep the current value): ");
        string name = ReadLine();
        if(!string.IsNullOrEmpty(name))
        {
            teacher.Name = name;
        }

        WriteLine("Enter new payroll (or press enter to keep the current value): ");    
        string payroll = ReadLine();
        if(!string.IsNullOrEmpty(payroll))
        {
            teacher.Payroll = payroll;
        }

        WriteLine("Enter new password (or press enter to keep the current value): ");
        string password = ReadLine();
        if(!string.IsNullOrEmpty(password))
        {
            teacher.Password = password;
        }

        WriteLine("Enter new subject (or press enter to keep the current value): ");
        string subjectinput = ReadLine();
        string[] subject = subjectinput.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        if(!string.IsNullOrEmpty(subjectinput))
        {
            teacher.Subject = subject;
        }

        WriteLine("Enter new division (or press enter to keep the current value): ");
        string division = ReadLine();
        if(!string.IsNullOrEmpty(division))
        {
            teacher.Division = division;
        }

        TeachersList[ID - 1] = teacher; // Ajustamos el índice
        SerializeTeacherJSON();
        SerializeTeacherToXml();
        
        WriteLine("Teacher edited successfully");
        } else
        {
        WriteLine("Invalid ID");
        }  
    }

    static void DeleteTeacher()
    {
        Write("ID of the teacher to delete: ");
        int ID = Convert.ToInt32(ReadLine());
        Teacher teacherToDelete = TeachersList.FirstOrDefault(teacher => teacher.TeacherID == ID);
        if(teacherToDelete != null)
        {
            TeachersList.Remove(teacherToDelete);
            SerializeTeacherToXml();
            SerializeTeacherJSON();
            WriteLine("Teacher deleted successfully"); 
        } else
        {
            WriteLine("Teacher not found");
        }
    }

    #endregion

    #region Storekeepers
    static List<StoreKeeper> StorekeepersList = new List<StoreKeeper>();
    static StoreKeeper currentStorekeeper;
    static void AddStorekeeper()
    {
        int StoreKeeperID = StorekeepersList.Any() ? StorekeepersList.Max(storeKeeper => storeKeeper.SKID) + 1 : 1;
        WriteLine("Enter name: ");
        string skname = ReadLine();
        WriteLine("Enter password: ");
        string skpassword = ReadLine();
        StoreKeeper storekeeper = new StoreKeeper(StoreKeeperID, skname, skpassword);
        StorekeepersList.Add(storekeeper);
        SerializeStorekeeperJSON();
        SerializeStorekeeperXML();
        WriteLine("Storekeeper added successfully");
    }

    static void Login()
    {
        WriteLine("Enter name: ");
        string skname = ReadLine();
        WriteLine("Enter password: ");
        string skpassword = ReadLine();
        skpassword = Encriptation.Decrypt(skpassword);
        StoreKeeper storekeeper = StorekeepersList.FirstOrDefault(storekeeper => storekeeper.SKName == skname && storekeeper.SKPassword == skpassword);
        if(storekeeper != null)
        {
            currentStorekeeper = storekeeper;
            WriteLine("Login successful");
        } else
        {
            WriteLine("Password or username incorrect");
        }
    }

    static void Logout()
    {
        currentStorekeeper = null;
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
                   
                    ChangeTeacherPassword();
                    break;
                case 2:
                    WriteLine("Change StoreKeeper Password");
                    ChangeStoreKeeperPassword();
                    break;
                case 3:
                    WriteLine("Exit");

                    Main();
                    break;
                default:
                    WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void ChangeTeacherPassword()
    {
        WriteLine("Enter the id of the teacher whose password you want to change: ");
        int Id = Convert.ToInt32(ReadLine());
        if(Id >= 0 && Id < TeachersList.Count)
        {
            Teacher teacher = TeachersList[Id];
            Write("Enter new password: ");
            string password = ReadLine();
            teacher.Password = password;
            TeachersList[Id] = teacher;
            SerializeTeacherToXml();
            SerializeTeacherJSON();
            WriteLine("Password changed successfully");
        }
        
    }

    static void ChangeStoreKeeperPassword()
    {
        WriteLine("Enter the id of the storekeeper whose password you want to change: ");
        int Id = Convert.ToInt32(ReadLine());
        if(Id >= 0 && Id < StorekeepersList.Count)
        {
            StoreKeeper storekeeper = StorekeepersList[Id];
            Write("Enter new password: ");
            string password = ReadLine();
            storekeeper.SKPassword = password;
            StorekeepersList[Id] = storekeeper;
            SerializeStorekeeperJSON();
            SerializeStorekeeperXML();
            WriteLine("Password changed successfully");
        }
    }
    #endregion

    #region  Serialize&DeserializeTeachers
    static void SerializeTeacherJSON()
    {
        string TeacherJson = JsonConvert.SerializeObject(TeachersList);
        File.WriteAllText("Teachers.json", TeacherJson);
    }
    static void DeserializeTeacherJSON()
    {
        if(File.Exists("Teachers.json"))
        {
            string TeacherJson = File.ReadAllText("Teachers.json");
            TeachersList = JsonConvert.DeserializeObject<List<Teacher>>(TeacherJson);
        } else
        {
            TeachersList = new List<Teacher>(); // Initialize TeachersList to an empty list
            WriteLine("No teachers found");
        }
    }

    static void SerializeTeacherToXml()
    {
        XmlSerializer Teacherserializer = new XmlSerializer(typeof(List<Teacher>));
        using (FileStream fileStream = File.OpenWrite("Teachers.xml"))
        {
            Teacherserializer.Serialize(fileStream, TeachersList.DistinctBy(teacher => teacher.TeacherID).ToList());
        }
    }

    static void DeserializeTeachersXml()
    {
        if (File.Exists("Teachers.xml"))
        {
            XmlSerializer Teacherserializer = new XmlSerializer(typeof(List<Teacher>));
            using (FileStream fileStream = File.OpenRead("Teachers.xml"))
            {
                TeachersList = (List<Teacher>)Teacherserializer.Deserialize(fileStream);
            }
        }
        else
        {
            TeachersList = new List<Teacher>(); // Initialize TeachersList to an empty list
            WriteLine("No teachers data file found.");
        }   
    }
    #endregion


    #region Serialize&DeserializeStorekeepers
    //STOREKEEPER JSON

    static void SerializeStorekeeperJSON()
    {
        string StorekeeperJson = JsonConvert.SerializeObject(StorekeepersList);
        File.WriteAllText("Storekeeper.json", StorekeeperJson);
    }

    static void DeserializeStorekeeperJSON()
    {
        if (File.Exists("Storekeeper.json"))
        {
            string StorekeeperJson = File.ReadAllText("storekeeper.json");
            StorekeepersList = JsonConvert.DeserializeObject<List<StoreKeeper>>(StorekeeperJson);
        }
        else
        {
            StorekeepersList = new List<StoreKeeper>(); // Initialize StorekeepersList to an empty list
            WriteLine("No storekeeper data file found.");
        }
    }

    //STOREKEEPER XML


    static void SerializeStorekeeperXML()
    {
        XmlSerializer Storekeeperserializer = new XmlSerializer(typeof(List<StoreKeeper>));
        using (FileStream fileStream = File.OpenWrite("Storekeeper.xml"))
        {
            Storekeeperserializer.Serialize(fileStream, StorekeepersList);
        }
    }

    static void DeserializeStorekeeperXML()
    {
        if (File.Exists("Storekeeper.xml"))
        {
            XmlSerializer Storekeeperserializer = new XmlSerializer(typeof(List<StoreKeeper>));
            using (FileStream fileStream = File.OpenRead("Storekeeper.xml"))
            {
                StorekeepersList = (List<StoreKeeper>)Storekeeperserializer.Deserialize(fileStream);
            }
        }
        else
        {
            StorekeepersList = new List<StoreKeeper>(); // Initialize StorekeepersList to an empty list
            WriteLine("No storekeeper data file found.");
        }
    }
    #endregion

    static void Main()
    {
        DeserializeTeacherJSON();
        DeserializeStorekeeperJSON();
        //DeserializeTeachersXml();
        DeserializeStorekeeperXML();
        Clear();
        WriteLine("\nWelcome to the Store Management System!");
        while(true) 
        {
            //Clear();
            if(currentStorekeeper == null)
            {
                WriteLine("\nLOGIN MENU:");
                WriteLine("1. Login");
                WriteLine("2. Add Storekeeper");
                WriteLine("3. Exit");
                Write("Enter your choice: ");
                string choice = ReadLine();
                switch(choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        WriteLine("Add Storekeeper");
                        AddStorekeeper();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Invalid choice");
                        break;
                }
            } 
            else
            {
                WriteLine($"Logged in as {currentStorekeeper.SKName}");
            }
            if (currentStorekeeper != null) 
            {
                WriteLine("\nMenu:");
                WriteLine("1. Add Teacher");
                WriteLine("2. See Teachers");
                WriteLine("3. Edit Teacher");
                WriteLine("4. Delete Teacher");
                WriteLine("5. Change Password");
                WriteLine("6. Report");
                WriteLine("7. Logout");
                WriteLine("8. Exit");
                Write("Enter your choice: ");
                string choice1 = ReadLine();
            switch(choice1)
            {
                case "1":
                    WriteLine("Add Teacher");
                    AddTeacher();
                    break;
                case "2":
                    WriteLine("See Teachers");
                    foreach(Teacher teacher in TeachersList)
                    {
                        WriteLine($"ID: {teacher.TeacherID}, Name: {teacher.Name}, Payroll: {teacher.Payroll}, Password: {teacher.Password}, Subject: {teacher.Subject}, Division: {teacher.Division}");
                    }
                    break;
                case "3":
                    EditTeacher();
                    break;
                case "4":
                    DeleteTeacher();
                    break;
                case "5":
                    WriteLine("Change Password");
                    ChangePasswordsSubMenu();
                    break;
                case "6":
                    WriteLine("Report");
                    break;
                case "7":
                    Logout();
                    break;
                case "8":
                    WriteLine("Exit");
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("Invalid choice");
                    break;        
            }  
            }
            
        }
    }
}