using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using OptionalWCF.Contracts;

namespace OptionalWCF.Client
{
    class CustomerServiceProxyWrapper: ClientBase<ICustomerService>, ICustomerService
    {
        [StructureMap.DefaultConstructor() ]
        public CustomerServiceProxyWrapper()
        {
        }

        public CustomerServiceProxyWrapper(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public CustomerServiceProxyWrapper(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public CustomerServiceProxyWrapper(string endpointConfigurationName,
                                              System.ServiceModel.EndpointAddress remoteAddress) :
                                                  base(endpointConfigurationName, remoteAddress)
        {
        }

        public CustomerServiceProxyWrapper(System.ServiceModel.Channels.Binding binding,
                                              System.ServiceModel.EndpointAddress remoteAddress) :
                                                  base(binding, remoteAddress)
        {
        }


        public Customer GetCustomer(int id)
        {
            return base.Channel.GetCustomer(id);
        }

        public void SaveCustomer(ref Customer customer)
        {
            base.Channel.SaveCustomer(ref customer);
        }
    }
}
