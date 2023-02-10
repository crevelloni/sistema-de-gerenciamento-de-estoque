using IMS_CoreBusiness;

namespace IMS_UseCases
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}