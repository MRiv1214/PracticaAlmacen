using System;

public class Teacher
{
    public string Name { get; set; }
    public string Payroll { get; set; }
    public string Password { get; set; }
    public string Subject { get; set; }
    public string Division { get; set; }

    public Teacher(string name, string payroll, string password, string subject, string division)
    {
        Name = name;
        Payroll = payroll;
        Password = password;
        Subject = subject;
        Division = division;
    }

    public override string ToString()
    {
        return $"Name: {Name}\nPayroll: {Payroll}\nPassword: {Password}\nSubject: {Subject}\nDivision: {Division}";
    }
    
    
}