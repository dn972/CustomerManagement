using AutoMapper;
using CRUDAccount.Models;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAccount
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
