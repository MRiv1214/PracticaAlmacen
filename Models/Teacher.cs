using System;
using System.IO;
using Newtonsoft.Json;

public class Teacher
{
    public int TeacherID { get; set; }
    public string Name { get; set; }
    public string Payroll { get; set; }
    public string Password { get; set; }
    public string[] Subject { get; set; }
    public string Division { get; set; }
    public List<Class> Classes { get; set; }
    
    public Teacher()
    {
        TeacherID = 1;
        Name = string.Empty;
        Payroll = string.Empty;
        Password = string.Empty;
        Subject =  new string[0];
        Division = string.Empty;
        Classes = new List<Class>();
    }
    public Teacher(int id, string name, string payroll, string password, string[] subject, string division)
    {
        TeacherID = id;
        Name = name;
        Payroll = Encriptation.Encrypt(payroll);
        Password = Encriptation.Encrypt(password);
        Subject = subject;
        Division = division;
        Classes = new List<Class>();
    }
}