using System.Net;

namespace HoNPrivateServerLanucher.UI.Models
{
    public class RegisterResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        public bool IsSuccess => Content?.Contains("Your account succifully activated") ?? false;
         
        public bool IsAccountAlreadyExists => Content?.Contains("User already exists") ?? false;
    }
}
