


namespace TestMVVM
{
    public class CustomerVM : VMBase
    {
        public Customers TheCustomer { get; set; }
        public CustomerVM()
        {
            // Initialise the entity or inserts will fail
            TheCustomer = new Customers();
            TheCustomer.CreditLimit = 5000;
            TheCustomer.Outstanding = 0;
        }

    }
}
