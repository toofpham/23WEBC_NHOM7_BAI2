namespace BT2.Models
{
    public class Product
    {
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public decimal DonGiaKhuyenMai { get; set; }
        public string HinhAnh { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public string LoaiSP { get; set; } = string.Empty;
    }
}
