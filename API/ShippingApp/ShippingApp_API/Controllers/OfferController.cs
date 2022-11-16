using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingApp_Domain.Models;
using ShippingApp_Service.Interfaces;
using ShippingApp_Service.Models;
using ShippingApp_Shared;

namespace ShippingApp_API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost("checkprice")]
        public async Task<IActionResult> CheckOfferPrice([FromBody] CheckPriceModel userEntity)
        {
            try
            {
                var offerModel = await _offerService.CalculatePrizeForCargoForYou(userEntity);

                if (offerModel.Count() == 0) throw new Exception(ErrorMessages.InvalidDimensions);

                return Ok(offerModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("saveoffer")]
        public async Task<IActionResult> SaveOffer([FromBody] UserOffersDTO userEntity)
        {
            try
            {
                var offerModel = await _offerService.SaveOffer(userEntity);
                return Ok(offerModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
