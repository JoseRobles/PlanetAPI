using System;
using System.Collections.Generic;
using System.Text;
using DTOs;

namespace Infrastructure
{
    public interface IService
    {
        void SetUrls(string securityUrl, string planetURL);
        void SetCredentials(string username, string password);
        SecurityResponse GetToken();
        IEnumerable<Planet> GetData();
    }
}
