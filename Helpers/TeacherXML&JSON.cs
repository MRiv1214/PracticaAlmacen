using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Xml.Serialization;
using static System.Console;
public class TeacherXMLJSON
{
    /*static List<Teacher> TeachersList = new List<Teacher>();

    public static void SerializeTeacherJSON()
    {
        string TeacherJson = JsonConvert.SerializeObject(TeachersList);
        File.WriteAllText("Teachers.json", TeacherJson);
    }

    public static void SerializeTeacherToXml()
    {
        XmlSerializer Teacherserializer = new XmlSerializer(typeof(List<Teacher>));
        using (FileStream fileStream = File.OpenWrite("Teachers.xml"))
        {
            //Teacherserializer.Serialize(fileStream, TeachersList.DistinctBy(teacher => teacher.TeacherID).ToList());
            Teacherserializer.Serialize(fileStream, TeachersList);
        }
    }


    public static void DeserializeTeacherJSON()
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
    public static void DeserializeTeacherXML()
    {
        if(File.Exists("Teachers.xml"))
        {
            XmlSerializer Teacherserializer = new XmlSerializer(typeof(List<Teacher>));
            using (FileStream fileStream = File.OpenRead("Teachers.xml"))
            {
                TeachersList = (List<Teacher>)Teacherserializer.Deserialize(fileStream);
            }
        } else
        {
            TeachersList = new List<Teacher>(); // Initialize TeachersList to an empty list
            WriteLine("No teachers found");
        }
    }
    static void SerializeTeachers()
    {
        SerializeTeacherJSON();
        SerializeTeacherToXml();
    }

    

    /*static void DeserializeTeachersXml()
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
    }*/
}