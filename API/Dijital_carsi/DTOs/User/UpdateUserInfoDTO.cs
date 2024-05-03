namespace Dijital_carsi.DTOs.User
{
    public class UpdateUserInfoDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
