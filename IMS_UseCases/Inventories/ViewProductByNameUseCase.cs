using IMS_CoreBusiness;
using IMS_UseCases.Interfaces;
using IMS_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_UseCases.Inventories
{
    public class ViewProductByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductByNameUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> ExecuteAsync(string name = "")
        {
            return await this.productRepository.GetProdutosNome(name);
        }


    }
}
