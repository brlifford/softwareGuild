using FlooringOrderSystem.Data;
using FlooringOrderSystem.Models;

namespace FlooringOrderSystem.BLL.Helpers
{
    public class DisplayProducts
    {
        FileProductRepository productRepo = new FileProductRepository();

        public void Show()
        {
            productRepo.DisplayProducts();
        }


        public Product Choose()
        {
            Product product = new Product();
            product = productRepo.ChooseProduct();
            return product;
        }
    }
}
