using Microsoft.Extensions.Configuration;
using ShippingApp_DataAccess.Interfaces;
using ShippingApp_Domain.Entities;
using ShippingApp_Domain.Models;
using ShippingApp_Service.Interfaces;
using ShippingApp_Service.Models;
using ShippingApp_Shared;
using ShippingApp_Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShippingApp_Service.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly IUserOffersRepository _userOffersRepository;
        private readonly IConfiguration _configuration;


        public OfferService(IUserOffersRepository userOffersRepository, IConfiguration configuration)
        {
            _userOffersRepository = userOffersRepository;
            _configuration = configuration;
        }

        public async Task<int> SaveOffer(UserOffersDTO dtoModel)
        {
            var offerSaved = await _userOffersRepository.Create(dtoModel.ToDomain());

            return offerSaved.Id;

        }

        public async Task<List<OfferModel>> CalculatePrizeForCargoForYou(CheckPriceModel model)
        {
            await RequiredField(model);

            List<OfferModel> offers = new();

            //calc volume
            double dimension = Convert.ToDouble(model.PackageHeight) * Convert.ToDouble(model.PackageWidth) * Convert.ToDouble(model.PackageDepth);
            //package weight
            double weight = Convert.ToDouble(model.PackageWeight);

            //Cargo4You
            if (weight <= 20 && dimension < 2000)
            {

                CargoForYou cargoForYou = new();
                //check offerPrice
                var offerPriceCargoForYou = cargoForYou.CalculatePrices(Convert.ToDouble(model.PackageWidth.Trim()),
                                                                        Convert.ToDouble(model.PackageHeight.Trim()),
                                                                        Convert.ToDouble(model.PackageDepth.Trim()),
                                                                        Convert.ToDouble(model.PackageWeight.Trim()));

                OfferModel newOfferModel = new() { CarrierName = "CargoForYou", OfferPrice = $"{Math.Round(offerPriceCargoForYou, 2)}$" };

                //add to return list of offers
                offers.Add(newOfferModel);
            }

            //ShipFaster
            if (weight > 10 && weight <= 30 && dimension <= 1700)
            {
                ShipFaster shipFaster = new();

                //check offerPrice
                var offerPriceCargoForYou = shipFaster.CalculatePrices(Convert.ToDouble(model.PackageWidth.Trim()),
                                                                       Convert.ToDouble(model.PackageHeight.Trim()),
                                                                       Convert.ToDouble(model.PackageDepth.Trim()),
                                                                       Convert.ToDouble(model.PackageWeight.Trim()));

                OfferModel newOfferModel = new() { CarrierName = "ShipFaster", OfferPrice = $"{Math.Round(offerPriceCargoForYou, 2)}$" };

                //add to return list of offers
                offers.Add(newOfferModel);
            }

            //Malta Ship
            if (weight >= 10 && dimension >= 500)
            {
                MaltaShip shipFaster = new();

                //check offerPrice
                var offerPriceCargoForYou = shipFaster.CalculatePrices(Convert.ToDouble(model.PackageWidth.Trim()),
                                                                       Convert.ToDouble(model.PackageHeight.Trim()),
                                                                       Convert.ToDouble(model.PackageDepth.Trim()),
                                                                       Convert.ToDouble(model.PackageWeight.Trim()));

                OfferModel newOfferModel = new() { CarrierName = "MaltaShip", OfferPrice = $"{Math.Round(offerPriceCargoForYou, 2)}$" };

                //add to return list of offers
                offers.Add(newOfferModel);

            }

            return offers;
        }

        public async Task<bool> RequiredField(CheckPriceModel model)
        {

            Regex numbersValidation = new Regex(_configuration["RegexValidation:OnlyNumbers"]);

            if (!numbersValidation.IsMatch(model.PackageHeight.Trim()))
                throw new Exception(ErrorMessages.InvalidHeight);

            if (!numbersValidation.IsMatch(model.PackageWidth.Trim()))
                throw new Exception(ErrorMessages.InvalidWidth);

            if (!numbersValidation.IsMatch(model.PackageDepth.Trim()))
                throw new Exception(ErrorMessages.InvalidDepth);

            if (!numbersValidation.IsMatch(model.PackageWeight.Trim()))
                throw new Exception(ErrorMessages.InvalidWeight);

            return await Task.FromResult(true);
        }
    }
}
