using IMS_CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetProdutosNome(string nome = "");
        Task<Product> GetProductById(int id);
        Task UpdateProductAsync(Product product);
        Task DeleteProduct(int idProduct);
    }
}
 