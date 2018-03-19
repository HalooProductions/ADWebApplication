using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haloo.DirectoryServices
{
    public class ADConfig
    {
        public string Domain { get; set; }
        public string SearchBase { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserDomainPrefix { get; set; }
    }
}
