
using ShippingApp_DataAccess.Interfaces;
using ShippingApp_Domain;
using ShippingApp_Domain.Entities;
using ShippingApp_Shared;

namespace ShippingApp_DataAccess.Repositories
{
    public class UserOffersRepository : IUserOffersRepository
    {
        private readonly ShippingAppDbContext _dbContext;


        public UserOffersRepository(ShippingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserOffers> Create(UserOffers offerModel)
        {

            if (offerModel is null) throw new Exception(ErrorMessages.InvalidOffer);

            try
            {
            
                await _dbContext.AddAsync(offerModel);
                await _dbContext.SaveChangesAsync();

                return offerModel;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
