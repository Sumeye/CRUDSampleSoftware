using AutoMapper;
using CrudSample.Core.DTOs;
using CrudSample.Core.Models;
using CrudSample.Core.Repositories;
using CrudSample.Core.Services;
using CrudSample.Core.UnitOfWork;
using CrudSample.Service.Exceptions;

namespace CrudSample.Service.Services
{
    public class UserService : Service<Users>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<Users> repository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByIdAsync(userUpdateDto.Id);
            if (user == null)
            {
                throw new ClientSideException($"{typeof(UserDto).Name} ({userUpdateDto.Id}) Not Found");
            }
            user.Name = userUpdateDto.Name ?? string.Empty;
            user.SurName = userUpdateDto.Name ?? string.Empty;
            user.Email = userUpdateDto.Email ?? string.Empty;
            user.Password = userUpdateDto.Password ?? string.Empty;
            _userRepository.Update(user);
        }
    }
}
