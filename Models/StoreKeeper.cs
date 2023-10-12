public class StoreKeeper
{
    public int SKID { get; set; }
    public string SKName { get; set; }
    public string SKPassword { get; set; }

    public StoreKeeper()
    {
        SKID = 1;
        SKName = string.Empty;
        SKPassword = string.Empty;
    }

    public StoreKeeper(int skid, string skname, string skpassword)
    {
        SKID = skid;
        SKName = skname;
        SKPassword = Encriptation.Encrypt(skpassword);
    }
}