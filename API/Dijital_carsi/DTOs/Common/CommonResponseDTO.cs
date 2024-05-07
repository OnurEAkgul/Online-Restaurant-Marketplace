namespace Dijital_carsi.DTOs.Common
{
    public class CommonResponseDTO<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Successful { get; set; }
    }
}
