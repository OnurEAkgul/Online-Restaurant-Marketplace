using Dijital_carsi.DTOs.User;

namespace Dijital_carsi.DTOs.Shop
{
    public class ShopResponseDTO
    {
       

        public string Message { get; set; }
        public List<ShopInfoDTO> Data { get; set; }

        public bool Successful { get; set; }


    }
}
