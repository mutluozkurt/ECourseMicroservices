using ECourse.Services.Basket.Dtos;
using ECourse.Shared.Dtos;
using System.Threading.Tasks;

namespace ECourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
