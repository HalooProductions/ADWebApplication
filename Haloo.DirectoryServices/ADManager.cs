using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haloo.DirectoryServices
{
    public class ADManager : IADManager
    {
        private ADConfig _config;

        public ADManager(ADConfig config)
        {
            _config = config;
        }

        public HalooUser GetDummyUser(string username)
        {
            return new HalooUser()
            {
                AccountName = username,
                DisplayName = "Dummy User",
                GivenName = "Dummy User",
                IsEnabled = true,
                LastName = "User",
                Title = "Dummy"
            };
        }

        public HalooUser FindUser(string username)
        {
            HalooUserPrincipal user = FindUserPrincipal(username);

            if (null == user)
            {
                return null;
            }

            return new HalooUser()
            {
                AccountName = user.SamAccountName,
                DisplayName = user.DisplayName,
                GivenName = user.DisplayName,
                IsEnabled = user.Enabled.GetValueOrDefault(),
                LastName = user.Surname,
                Title = user.Title
            };
        }

        private HalooUserPrincipal FindUserPrincipal(string username)
        {
            var principalContext = GetPrincipalContext();
            // 2. luodaan malliobjekti, jota haetaan AD:sta
            HalooUserPrincipal model = new HalooUserPrincipal(principalContext);
            model.SamAccountName = username;

            // 3. tehdään haku
            PrincipalSearcher searcher = new PrincipalSearcher(model);
            var user = (HalooUserPrincipal)searcher.FindOne();
            searcher.Dispose();
            return user;
        }

        public void UpdateUser(HalooUser user)
        {
            // tehdään validointi muokattavalle objektille
            if (null == user || string.IsNullOrEmpty(user.AccountName))
            {
                throw new ArgumentException($"{nameof(user)} is null or {nameof(HalooUser.AccountName)} is null or empty.");
            }

            var userPrincipal = FindUserPrincipal(user.AccountName);
            if (null == userPrincipal)
            {
                new ArgumentException($"A user {user.AccountName} was not found.");
            }

            // asetataan attribuuteille uudet arvot
            userPrincipal.Title = user.Title;
            // + muut muokattavat attribuutit
            userPrincipal.Save();
        }

        private PrincipalContext GetPrincipalContext()
        {
            PrincipalContext principalContext = null;
            if (string.IsNullOrEmpty(_config?.Username) ||
                string.IsNullOrEmpty(_config?.Password))
            {
                principalContext = new PrincipalContext(ContextType.Domain,
                _config.Domain, _config.SearchBase, ContextOptions.Negotiate);
            }
            else
            {
                principalContext = new PrincipalContext(ContextType.Domain,
                _config.Domain,
                _config.SearchBase,
                ContextOptions.Negotiate,
                _config.Username,
                _config.Password);
            }
            return principalContext;
        }
    }
}
