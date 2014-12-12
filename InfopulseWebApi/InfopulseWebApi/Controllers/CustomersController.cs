using System;
using System.Collections.Generic;
using System.Web.Http;
using InfopulseWebApi.Customers;
using InfopulseWebApi.Services;

namespace InfopulseWebApi.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;


        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IList<CustomerDto> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        public CustomerDto GetCustomer(Int64 id)
        {
            return _customerService.GetCustomerById(id);
        }


        [HttpPost]
        public void AddCustomer([FromBody]CustomerDto newCustomer)
        {
            _customerService.CreateCustomer(newCustomer);
        }
        

        [HttpPut]
        public void UpdateCustomer(CustomerDto customer)
        {
            _customerService.UpdateCustomer(customer);
        }

        
        [HttpDelete]
        public void Delete([FromUri]Int64 id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}