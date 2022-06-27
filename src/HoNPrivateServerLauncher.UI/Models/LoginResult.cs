using System.Net;

namespace HoNPrivateServerLanucher.UI.Models
{
    public class LoginResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        // TODO: Add success handling
        public bool IsSuccess => Content?.Contains("??") ?? false;
         
        public bool IsLoginOrPasswordIncorrect => Content?.Contains("Incorrect login or password") ?? false;
    }
}
