﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectZ.BLL.Interfaces;
using ProjectZ.DAL.Interfaces;

namespace ProjectZ.BLL.Services
{
    public class EntityService<T> : IEntityService<T> where T: class
    {
        protected readonly IRepository<T> _repository;
        public EntityService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
        public T GetEntityById(int id)
        {
            return _repository.GetEntity(id);
        }
        public void Create(T item)
        {
            _repository.Create(item);
        }
        public void Update(T item)
        {
            _repository.Update(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
