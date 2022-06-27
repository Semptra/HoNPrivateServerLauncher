using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HoNPrivateServerLanucher.UI.Models;

namespace HoNPrivateServerLanucher.UI
{
    public class HoNServerClient
    {
        private const string RegisterUri = "http://hon-server.ddns.net/auth.php?act=register";
        private const string LoginUri = "http://hon-server.ddns.net/auth.php?act=login";

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<RegisterResult> Register(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, RegisterUri)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "login", login },
                    { "password", password }
                })
            };

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return new RegisterResult
            {
                StatusCode = response.StatusCode,
                Content = content
            };
        }

        public async Task<LoginResult> Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, LoginUri)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "login", login },
                    { "password", password }
                })
            };

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return new LoginResult
            {
                StatusCode = response.StatusCode,
                Content = content
            };
        }
    }
}