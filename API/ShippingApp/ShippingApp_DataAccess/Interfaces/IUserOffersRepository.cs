
using ShippingApp_Domain.Entities;
using ShippingApp_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_DataAccess.Interfaces
{
    public interface IUserOffersRepository
    {
        Task<UserOffers> Create(UserOffers offerModel);
    }
}
