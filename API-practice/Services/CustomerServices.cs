using API_practice.Interface;
using API_practice.Model;

namespace API_practice.Services
{
    public class CustomerServices : ICustomerList
    {
        private List<Customers> _customerItems;

        public CustomerServices()
        {
            _customerItems = new List<Customers>();
        }

        public List<Customers> GetCustomer()
        {
            return _customerItems;
        }

        public Customers AddCustomer(Customers customer)
        {
            _customerItems.Add(customer);
            return customer;
        }
        public Customers UpdateCustomers(string id, Customers customers)
        {
            for (var index =  _customerItems.Count - 1; index >= 0; index--)
            {
                if (_customerItems[index].CustomerID ==  id)
                {
                    _customerItems[index] = customers;
                }
            }
            return customers;
        }

        public string DeleteCustomers(string id)
        {
            for (var index = _customerItems.Count - 1; index >= 0; index--)
            {
                if (_customerItems[index].CustomerID == id)
                {
                    _customerItems.RemoveAt(index);
                }
            }
            return id;
        }
    }
}
