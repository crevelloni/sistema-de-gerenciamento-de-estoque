using IMS_CoreBusiness;
using IMS_UseCases.Interfaces;
using IMS_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_UseCases
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository? productRepository;

        //public EditProductUseCase(IProductRepository productRepository)
        //{
        //    this.productRepository = productRepository;
        //}
        public async Task ExecuteAsync(Product product)
        {

            await this.productRepository.UpdateProductAsync(product);

        }


    }
}
