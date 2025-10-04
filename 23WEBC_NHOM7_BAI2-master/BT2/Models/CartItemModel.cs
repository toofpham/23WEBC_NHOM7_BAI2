namespace BT2.Models
{
    public class CartItemModel
    {
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public decimal DonGiaKhuyenMai { get; set; }
        public string HinhAnh { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public string LoaiSP { get; set; } = string.Empty;
        public int SoLuong { get; set; }

        
        public decimal ThanhTien => DonGia * SoLuong;

        public CartItemModel() { }

        public CartItemModel(Product p)
        {
            MaSP = p.MaSP;
            TenSP = p.TenSP;
            DonGia = p.DonGia;
            DonGiaKhuyenMai = p.DonGiaKhuyenMai;
            HinhAnh = p.HinhAnh;
            MoTa = p.MoTa;
            LoaiSP = p.LoaiSP;
            SoLuong = 1;
        }
    }
}
