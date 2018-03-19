using System.DirectoryServices.AccountManagement;

namespace Haloo.DirectoryServices
{
    // oma käyttäjäobjekti
    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("User")]
    public class HalooUserPrincipal : UserPrincipal
    {
        public const string TitleAttribute = "title";

        public HalooUserPrincipal(PrincipalContext context) : base(context)
        { }

        // yhdistetään luokan Title-property AD:n title-attribuuttiin
        [DirectoryProperty(TitleAttribute)]
        public string Title
        {
            get
            {
                var attr = ExtensionGet(TitleAttribute);
                if (attr.Length != 1)
                {
                    return null;
                }
                return (string)attr[0];
            }
            set
            {
                ExtensionSet(TitleAttribute, value);
            }
        }
    }
}
