using AutoMapper;
using CrudSample.Core.DTOs;
using CrudSample.Core.Models;
using CrudSample.Core.Repositories;
using CrudSample.Core.Services;
using CrudSample.Core.UnitOfWork;
using CrudSample.Repository.UnitOfWork;
using CrudSample.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Service.Services
{
    public class UserService : Service<Users>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IGenericRepository<Users> repository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        public async Task UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByIdAsync(userUpdateDto.Id);
            _userRepository.Update(user, _mapper.Map<Users>(userUpdateDto));
            await _unitOfWork.CommitAsync();
        }
    }
}
