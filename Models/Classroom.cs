public class Classroom
{
    public int ClassroomID { get; set; }
    public string ClassroomName { get; set; }
    public List<Class> Classes { get; set; }


    public Classroom()
    {
        ClassroomID = 1;
        ClassroomName = string.Empty;
        Classes = new List<Class>();
        
    }
    public Classroom(int classroomid, string classroomname)
    {
        ClassroomID = classroomid;
        ClassroomName = classroomname;
        Classes = new List<Class>();
        
    }
}