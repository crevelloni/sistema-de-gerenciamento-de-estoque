using IMS_CoreBusiness;

namespace IMS_UseCases
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}