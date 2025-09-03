using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories
{
    public class UserTaskRepository: GenericRepository<UserTask>, IUserTaskRepository
    {

        private readonly ApplicationDbContext dbContext;

        public UserTaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<UserTask>> GetById(int id)
        {
            return await dbContext.UserTasks
             .Where(t => t.UserId == id)
             .ToListAsync();
        }

        public async Task<UserTask> GetTaskById(int id)
        {
            return await dbContext.UserTasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> UpdateState(int id,int state)
        {
            var task = dbContext.UserTasks.FirstOrDefault(t => t.Id == id);

            task.State = state;
            dbContext.UserTasks.Update(task);
            await dbContext.SaveChangesAsync();

            return task.Id;

        }
    }
}
