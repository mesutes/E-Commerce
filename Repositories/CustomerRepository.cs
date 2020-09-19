using E_Commerce.Entities;
using E_Commerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
    }
}
