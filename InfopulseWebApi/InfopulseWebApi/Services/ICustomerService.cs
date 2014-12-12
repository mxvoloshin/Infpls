using System;
using System.Collections.Generic;
using InfopulseWebApi.Customers;

namespace InfopulseWebApi.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDto customer);
        CustomerDto GetCustomerById(Int64 id);
        IList<CustomerDto> GetCustomers();
        void DeleteCustomer(Int64 id);
        void UpdateCustomer(CustomerDto customer);
    }
}