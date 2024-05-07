namespace Dijital_carsi.DTOs.Shop
{
    public class ShopUpdateRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string LogoUrl { get; set; }
        public bool IsOpen { get; set; }
    }
}
