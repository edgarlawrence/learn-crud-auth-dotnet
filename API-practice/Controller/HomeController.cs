using API_practice.Interface;
using API_practice.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_practice.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private ILogger _logger;
        private ICustomerList _customerServices;
        public HomeController(ILogger<HomeController> logger, ICustomerList customerService)
        {
            _logger = logger;
            _customerServices = customerService;
        }

        [HttpGet("/api/customers")]
        public ActionResult<List<Customers>> GetProducts()
        {
            return _customerServices.GetCustomer();
        }

        [HttpGet("/api/customers/{id}")]
        public ActionResult<Customers> GetProductByID(string id)
        {
            var customer = _customerServices.GetCustomer();
            var customerID = customer.FirstOrDefault(x => x.CustomerID == id);

            if(customerID != null)
            {
                return customerID;
            } else
            {
                return null;
            }
        }

        [HttpPost("/api/customers")]
        public ActionResult<Customers> AddProduct(Customers customers)
        {
            _customerServices.AddCustomer(customers);
            return customers;
        }

        [HttpPut("/api/customers/{id}")]
        public ActionResult<Customers> UpdateProduct(string id,Customers customers)
        {
            _customerServices.UpdateCustomers(id, customers);
            return customers;
        }

        [HttpDelete("/api/customers/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _customerServices.DeleteCustomers(id);
            return id;
        }
    }
}
