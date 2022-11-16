using AutoMapper;
using ShippingApp_Domain.Entities;
using ShippingApp_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Shared.Mapper
{
    public static class Mapper
    {
        //Domain to DTO
        public static UserOffersDTO ToDto(this UserOffers domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserOffers, UserOffersDTO>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<UserOffersDTO>(domainModel);
        }

        //DTO To Domain
        public static UserOffers ToDomain(this UserOffersDTO domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserOffersDTO, UserOffers>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<UserOffers>(domainModel);
        }
    }
}
