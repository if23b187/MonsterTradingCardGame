using System.Text.Json;
using MonsterTradingCardGame.HTTP;

namespace MonsterTradingCardGame
{
    internal class UserRequestHandler
    {
        private readonly Dictionary<string, User> _userDatabase;

        public UserRequestHandler(Dictionary<string, User> users)
        {
            _userDatabase = users;
        }

        public void ProcessRequest(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            switch (httpRequest.HttpMethod)
            {
                case "POST" when httpRequest.UrlPath == "/users":
                    HandleUserRegistration(httpRequest.BodyContent, httpResponse);
                    break;

                case "POST" when httpRequest.UrlPath == "/sessions":
                    HandleUserLogin(httpRequest.BodyContent, httpResponse);
                    break;

                default:
                    httpResponse.SendResponse("HTTP/1.0 404 Not Found", "Invalid Route");
                    break;
            }
        }

        private void HandleUserRegistration(string bodyContent, HttpResponse response)
        {
            var newUser = JsonSerializer.Deserialize<User>(bodyContent);
            if (newUser != null && !_userDatabase.ContainsKey(newUser.Username))
            {
                _userDatabase[newUser.Username] = newUser;
                response.SendResponse("HTTP/1.0 201 Created", "User registered");
            }
            else
            {
                response.SendResponse("HTTP/1.0 400 Bad Request", "User already registered");
            }
        }

        private void HandleUserLogin(string bodyContent, HttpResponse response)
        {
            var loginUser = JsonSerializer.Deserialize<User>(bodyContent);
            if (loginUser != null && _userDatabase.TryGetValue(loginUser.Username, out var existingUser) &&
                existingUser.Password == loginUser.Password)
            {
                response.SendResponse("HTTP/1.0 200 OK", "Login successful");
            }
            else
            {
                response.SendResponse("HTTP/1.0 401 Unauthorized", "Invalid Username or Password");
            }
        }
    }
}
