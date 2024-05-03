namespace Dijital_carsi.DTOs.User
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public bool RememberMe { get; set; }
    }
}
