using CrudSample.Core.DTOs;
using CrudSample.Core.Models;

namespace CrudSample.Core.Services
{
    public interface IUserService : IService<Users>
    {
        Task UpdateAsync(UserUpdateDto userUpdateDto);
    }
}
