using ShippingApp_Domain.Entities;
using ShippingApp_Domain.Models;
using ShippingApp_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Service.Interfaces
{
    public interface IOfferService
    {
        Task<List<OfferModel>> CalculatePrizeForCargoForYou(CheckPriceModel model);
        Task<int> SaveOffer(UserOffersDTO model);
    }
}
