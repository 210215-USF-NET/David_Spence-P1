using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreMVC.Models
{
    public class Mapper : IMapper
    {
        public Customer cast2Customer(CustomerCRVM customer2aBCasted)
        {
            return new Customer
            {
                Name = customer2aBCasted.Name,
                Phone = customer2aBCasted.Phone
            };
        }

        public Customer cast2Customer(CustomerEditVM customer2BCasted)
        {
            throw new NotImplementedException();
        }

        public CustomerCRVM cast2CustomerCRVM(Customer customer)
        {
            return new CustomerCRVM
            {
                Name = customer.Name,
                Phone = customer.Phone
            };
        }

        /*public CustomerEditVM cast2CustomerEditVM(Customer customer)
        {
            return new CustomerEditVM
            {
                Name = customer.Name,
                Phone = customer.Phone
            };
        }*/

        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted)
        {
            return new CustomerIndexVM
            {
                Name = customer2BCasted.Name,
                Phone = customer2BCasted.Phone
            };
        }
    }
}
