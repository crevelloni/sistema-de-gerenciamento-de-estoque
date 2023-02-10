using IMS_CoreBusiness;

namespace IMS_UseCases
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string nome = "");
    }
}