using System.Collections.ObjectModel;

namespace TestMVVM
{
    public class CustomersViewModel : CrudVMBase
    {

        public ObservableCollection<CustomerVM> Customers { get; set; }
        public CustomersViewModel()
        {
        }
    }
}
