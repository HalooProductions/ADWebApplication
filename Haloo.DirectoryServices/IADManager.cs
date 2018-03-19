namespace Haloo.DirectoryServices
{
    public interface IADManager
    {
        HalooUser FindUser(string username);
        void UpdateUser(HalooUser user);
    }
}