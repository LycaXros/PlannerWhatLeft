using System.Collections.ObjectModel;

namespace TestMVVM
{
    public class ProductsViewModel: CrudVMBase
    {

        public ObservableCollection<ProductVM> Products { get; set; }
        public ProductsViewModel()
        {
        }
    }
}
