using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptionalWCF.Contracts;
using StructureMap;

namespace OptionalWCF.Client
{
    class Program
    {
        private static void Main(string[] args)
        {
            ObjectFactory.Initialize(x =>
            {
                x.PullConfigurationFromAppConfig = true;
            });

            var main = new Program();
            main.Start();
        }

        private void Start()
        {
            var customerServices = ObjectFactory.GetInstance<ICustomerService>();

            var customer1 = customerServices.GetCustomer(1);
            
            Console.WriteLine("Customer 1 Last name is '{0}'", customer1.LastName);

            var newCustomer = new Customer() {FirstName = "Sue", LastName = "Queue"};
            customerServices.SaveCustomer(ref newCustomer);

            Console.WriteLine("New Customer ID is '{0}', FirstName: {1}, LastName: {2}", newCustomer.Id, newCustomer.FirstName, newCustomer.LastName);

            newCustomer.LastName = "Smith"; 
            customerServices.SaveCustomer(ref newCustomer);

            Console.WriteLine("New Customer ID is '{0}', FirstName: {1}, LastName: {2}", newCustomer.Id, newCustomer.FirstName, newCustomer.LastName);

            Console.Read();
        }
    }
}
