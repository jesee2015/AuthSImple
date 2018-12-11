using System;
using System.Net.Http;
using IdentityModel.Client;

namespace Shakelx.Auth.ThirdPartyDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            #region  不需要用户名和密码

            //var diso = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            //if (diso.IsError)
            //{
            //    Console.WriteLine(diso.Error);
            //}

            //var tokenClient = new TokenClient(diso.TokenEndpoint, "client", "secret");
            //var tokenResponse = tokenClient.RequestClientCredentialsAsync("api").Result;
            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //}
            //else
            //{
            //    Console.WriteLine(tokenResponse.Json);
            //}

            //HttpClient httpClient = new HttpClient();
            //httpClient.SetBearerToken(tokenResponse.AccessToken);
            //var response = httpClient.GetAsync("http://localhost:5001/api/values").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //}
            #endregion

            #region 使用用户名和密码来登陆
            var diso = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            if (diso.IsError)
            {
                Console.WriteLine(diso.Error);
            }
            var tokenClient = new TokenClient(diso.TokenEndpoint, "pwdClient", "secret");
            var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api").Result;
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            else
            {
                Console.WriteLine(tokenResponse.AccessToken);
            }

            HttpClient httpClient = new HttpClient();
            httpClient.SetBearerToken(tokenResponse.AccessToken);
            var response = httpClient.GetAsync("http://localhost:5001/api/values").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            #endregion
            Console.Read();
        }
    }
}
