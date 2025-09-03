using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;
using ToDoList.Application.Features.Commands;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();

            // Görev komutları
            CreateMap<CreateUserTaskCommand, UserTask>();

            // DTO varsa:
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserTask, UserTaskDTO>().ReverseMap();

        }
    }
}
