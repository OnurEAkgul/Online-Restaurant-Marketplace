namespace Dijital_carsi.DTOs.User
{
    public class LoginResponseDTO
    {
        public string Message { get; set; }
        public string Token { get; set; }

        public bool Successful { get; set; }
    }
}
