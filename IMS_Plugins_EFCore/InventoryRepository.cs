using IMS_CoreBusiness;
using IMS_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS_Plugins_EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext db;

        public InventoryRepository(IMSContext db)
        {
            this.db = db;

        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await this.db.Inventories.Where(x => x.InventoryName.Contains(name, StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            if (this.db.Inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.InvariantCultureIgnoreCase))) return;
            this.db.Inventories.Add(inventory);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateInventory(Inventory inventory)
        {
            if (this.db.Inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                                         x.InventoryName.Equals(inventory.InventoryName, StringComparison.InvariantCultureIgnoreCase))) return;
            var inv = await this.db.Inventories.FindAsync(inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
                await this.db.SaveChangesAsync();

            }
        }
        public async Task<Inventory?> GetInventoryAsync(int inventoryId)
        {
            return await this.db.Inventories.FindAsync(inventoryId);

        }
    }
}