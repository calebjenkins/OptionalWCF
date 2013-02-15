using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace OptionalWCF.Contracts
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Customer GetCustomer(int id);

        [OperationContract]
        void SaveCustomer(ref Customer customer);
    }

   
}
