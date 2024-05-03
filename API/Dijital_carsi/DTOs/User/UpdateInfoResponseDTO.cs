namespace Dijital_carsi.DTOs.User
{
    public class UpdateInfoResponseDTO
    {
        public string Message { get; set; }
        public UserInfoDTO Data { get; set; }

        public bool Successful { get; set; }
    }
}
