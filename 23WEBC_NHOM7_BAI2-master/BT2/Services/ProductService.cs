using System.Text.Json;
using BT2.Models;

namespace BT2.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(string id);   
        void SetProducts(List<Product> products);
        void AddProduct(Product product);
        void SaveToFile(string filePath);

    }

    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product>();

        public List<Product> GetAll() => _products;

        public Product? GetById(string id)
            => _products.FirstOrDefault(p => p.MaSP == id);

        public void SetProducts(List<Product> products)
        {
            _products.Clear();
            _products.AddRange(products);
        }

        public void AddProduct(Product product)
        {
            // Nếu muốn auto tăng ID dạng string
            if (_products.Count > 0)
            {
                int maxId = _products
                    .Select(p => int.TryParse(p.MaSP, out var num) ? num : 0)
                    .Max();
                product.MaSP = (maxId + 1).ToString();
            }
            else
            {
                product.MaSP = "1";
            }

            _products.Add(product);
        }

        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
