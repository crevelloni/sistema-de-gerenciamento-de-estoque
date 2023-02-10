using IMS_CoreBusiness;

namespace IMS_UseCases.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}