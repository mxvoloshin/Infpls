using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Infopulse.Core.Model;
using Infopulse.EntityFramework.Repository;
using InfopulseWebApi.Customers;

namespace InfopulseWebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer, long> _repository;

        public CustomerService(IRepository<Customer, long> repository)
        {
            _repository = repository;
        }

        public void CreateCustomer(CustomerDto dto)
        {
            var customer = Mapper.Map<Customer>(dto);
            _repository.Create(customer);
            _repository.SaveChanges();
        }

        public CustomerDto GetCustomerById(Int64 id)
        {
            var customer = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            return Mapper.Map<CustomerDto>(customer);
        }

        public IList<CustomerDto> GetCustomers()
        {
            var customer = _repository.GetAll().ToList();
            return Mapper.Map<List<CustomerDto>>(customer);
        }

        public void DeleteCustomer(Int64 id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void UpdateCustomer(CustomerDto dto)
        {
            var customer = Mapper.Map<Customer>(dto);
            _repository.Update(customer);
            _repository.SaveChanges();
        }
    }
}
