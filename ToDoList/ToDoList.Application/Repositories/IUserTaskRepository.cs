using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Repositories
{
    public interface IUserTaskRepository : IGenericRepository<UserTask>
    {
        Task<List<UserTask>> GetById(int id);
        Task<UserTask> GetTaskById(int id);
        Task<int> UpdateState(int id, int state);
    }
}
