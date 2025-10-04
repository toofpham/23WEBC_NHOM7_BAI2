using System.Text.Json;
using BT2.Models;
using BT2.Services;

namespace BT2.Middlewares
{
    public class ProductLoadingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private bool _loaded = false;

        public ProductLoadingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, IProductService productService)
        {

            if (!_loaded)
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data", "db.json");
                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);
                    var root = JsonDocument.Parse(json);
                    var products = root.RootElement.EnumerateArray();

                    foreach (var p in products)
                    {
                        var product = new Product
                        {
                            MaSP = p.GetProperty("MaSP").GetString() ?? "",
                            TenSP = p.GetProperty("TenSP").GetString() ?? "",
                            DonGia = p.GetProperty("DonGia").GetDecimal(),
                            DonGiaKhuyenMai = p.GetProperty("DonGiaKhuyenMai").GetDecimal(),
                            HinhAnh = p.GetProperty("HinhAnh").GetString() ?? "",
                            MoTa = p.GetProperty("MoTa").GetString() ?? "",
                            LoaiSP = p.GetProperty("LoaiSP").GetString() ?? ""
                        };
                        productService.AddProduct(product);
                    }
                }
                _loaded = true;
            }
            await _next(context);
        }
    }
}