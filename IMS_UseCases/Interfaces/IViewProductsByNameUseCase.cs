using IMS_CoreBusiness;

namespace IMS_UseCases.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<List<Product>> ExecuteAsync(string nome = "");

    }
}
