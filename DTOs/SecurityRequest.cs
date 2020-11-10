using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    [Serializable]
    public class SecurityRequest
    {
        public string email { get; set; }
        public string passphrase { get; set; }
    }
}
