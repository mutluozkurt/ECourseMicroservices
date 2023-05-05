using ECourse.Services.Catalog.Dtos;
using ECourse.Services.Catalog.Models;
using ECourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);

    }
}
