using IMS_CoreBusiness;

namespace IMS_UseCases
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory?> ExecuteAsync(int idInventory);
    }
}