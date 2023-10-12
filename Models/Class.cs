public class Class
{
    public int ClassID { get; set; }
    public int TeacherID { get; set; }
    public int GroupID { get; set; }



    public Teacher Teacher { get; set; }
    public Group Group { get; set; }
    public Classroom Classroom { get; set; }



    public Class()
    {
        ClassID = 0;
        TeacherID = 0;
        GroupID = 0;
        Teacher = new Teacher();
        Group = new Group();
        Classroom = new Classroom();
    }

    public Class(int classid, int teacherid, int groupid)
    {
        ClassID = classid;
        TeacherID = teacherid;
        GroupID = groupid;
        Teacher = new Teacher();
        Group = new Group();
        Classroom = new Classroom();
    }
}