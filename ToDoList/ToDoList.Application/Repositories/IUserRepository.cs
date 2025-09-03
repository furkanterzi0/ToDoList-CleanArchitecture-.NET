using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUser(string username, string password);
    }
}
