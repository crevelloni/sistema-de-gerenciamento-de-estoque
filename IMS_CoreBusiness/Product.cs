using IMS_CoreBusiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS_CoreBusiness
{
    public class Product
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater to {0}")]  
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater to {0}")]
        [Product_EnsurePricingIsGreaterThanInventoriesPrice]
        public double Price { get; set; }
        public List<ProductInventory>? ProductInventories { get; set; }

        public bool Flg_Inativo { get; set; } = false;

        public double TotalInventoryCost()
        {
            return this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        public bool ValidatePricing()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0) return true;

          
            if (TotalInventoryCost() > Price) return false;

            return true;
        }

    }
}
