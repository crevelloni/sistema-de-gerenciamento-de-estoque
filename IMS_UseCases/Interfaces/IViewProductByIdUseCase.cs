using IMS_CoreBusiness;

namespace IMS_UseCases.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExeuteAsync(int productId);
    }
}