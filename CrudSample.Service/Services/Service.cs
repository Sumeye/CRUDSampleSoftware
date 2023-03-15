using CrudSample.Core.Repositories;
using CrudSample.Core.Services;
using CrudSample.Core.UnitOfWork;
using CrudSample.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasUser = await _repository.GetByIdAsync(id);
            if (hasUser == null)
            {
                throw new ClientSideException($"{typeof(T).Name} ({id}) Not Found");
            }
            return hasUser;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
        }
    }
}
