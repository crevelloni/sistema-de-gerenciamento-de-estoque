using IMS_CoreBusiness;
using IMS_UseCases.PluginInterfaces;

namespace IMS_UseCases
{
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string nome = "")
        {
            return await this.inventoryRepository.GetInventoriesByName(nome);
        }





    }
}