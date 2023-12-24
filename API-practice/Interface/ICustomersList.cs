using API_practice.Model;

namespace API_practice.Interface
{
    public interface ICustomerList
    {
        public List<Customers> GetCustomer();
        public Customers AddCustomer(Customers customer);
        public Customers UpdateCustomers(string id, Customers customers);
        public string DeleteCustomers(string id);
    }
}
