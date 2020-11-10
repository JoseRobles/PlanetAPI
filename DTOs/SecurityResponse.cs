using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    [Serializable]
    public class SecurityResponse
    {
        public string hi { get; set; }
        public string dont_tell_anyone_this_token { get; set; }
    }
}
