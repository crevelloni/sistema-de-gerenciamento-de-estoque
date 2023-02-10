using IMS_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_UseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _repository;
        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }

        public async Task ExecuteAsync(int idProduct)
        {
            await this._repository.DeleteProduct(idProduct);
        }

    }
}
