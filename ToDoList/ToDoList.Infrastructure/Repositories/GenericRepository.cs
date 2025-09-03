using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddAsync(T entity)
        {
            await applicationDbContext.Set<T>().AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await applicationDbContext.Set<T>().ToListAsync();
        }
    }
}
