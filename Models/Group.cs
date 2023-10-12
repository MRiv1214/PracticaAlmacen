public class Group
{
    public int GroupID { get; set; }
    public string GroupName { get; set; }
    public List<Class> Classes { get; set; }

    public Group()
    {
    GroupID = 1;
    GroupName = string.Empty;
    Classes = new List<Class>();
    }
    
    public Group(int groupid, string groupname)
    {
    GroupID = groupid;
    GroupName = groupname;
    Classes = new List<Class>();
    }
}

