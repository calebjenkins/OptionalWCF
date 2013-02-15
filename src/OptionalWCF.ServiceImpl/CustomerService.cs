using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using OptionalWCF.Contracts;

namespace OptionalWCF.ServiceImpl
{

    public class CustomerService : ICustomerService
    {
        readonly List<Customer> _customers = new List<Customer>();
 
        public CustomerService()
        {
            _customers.Add(new Customer(){Id =1, FirstName="Joe", LastName ="Blow"});
            _customers.Add(new Customer() { Id = 2, FirstName = "Jack", LastName = "Black" });
        }

        public Customer GetCustomer(int id)
        {
            var result = _customers.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new FaultException<ApplicationException>(
                    new ApplicationException(String.Format("Id '{0}' is not a valid Customer ID", id)));
            }

            return result;
        }

        public void SaveCustomer(ref Customer customer)
        {
            int customerId = customer.Id;

            var existingCustomer = _customers.FirstOrDefault(x => x.Id == customerId);
            if (existingCustomer == null)
            {
                customer.Id = _customers.Count + 1;
                _customers.Add(customer);
            }
            else
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
            }
           
        }
    }
}
