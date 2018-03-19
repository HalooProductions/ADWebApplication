namespace Haloo.DirectoryServices
{
    public class HalooUser
    {
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string AccountName { get; set; }
        public string Title { get; set; }
        public bool IsEnabled { get; set; }

        public override string ToString()
        {
            var s = $"DisplayName: {DisplayName}";
            s = $"{s}\nGivenName: {GivenName}";
            s = $"{s}\nLastName: {LastName}";
            s = $"{s}\nAccountName: {AccountName}";
            s = $"{s}\nTitle: {Title}";
            s = $"{s}\nEnabled: {IsEnabled}";
            return s;
        }
    }
}
