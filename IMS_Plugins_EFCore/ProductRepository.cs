using IMS_CoreBusiness;
using IMS_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS_Plugins_EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext db;
        public ProductRepository(IMSContext db)
        {
            this.db = db;
        }
        public async Task<List<Product>> GetProdutosNome(string name)
        {
            return await this.db.TAB_Produto.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                                                        string.IsNullOrWhiteSpace(name) ||
                                                                        p.Flg_Inativo == false).ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            if (db.TAB_Produto.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            db.TAB_Produto.Add(product);
            await db.SaveChangesAsync();

            var prods = db.TAB_Produto.Include(x => x.ProductInventories).ThenInclude(x => x.Inventory).ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await this.db.TAB_Produto.Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProdutoId == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (this.db.TAB_Produto.Any(c => c.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            var prod = await db.TAB_Produto.FindAsync(product.ProdutoId);

            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.ProductInventories = product.ProductInventories;

                await db.SaveChangesAsync();

            }

        }

        public async Task DeleteProduct(int idProduct)
        {
            var prod = await this.db.TAB_Produto.FindAsync(idProduct);
            if(prod is not null)
            {
                prod.Flg_Inativo = true;
                await db.SaveChangesAsync();
            }
        }
    }
}
