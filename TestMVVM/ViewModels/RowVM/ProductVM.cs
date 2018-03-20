

namespace TestMVVM
{
    public class ProductVM
    {
        public Products TheProduct { get; set; }
        public ProductVM()
        {
            TheProduct = new Products();
        }
    }
}
