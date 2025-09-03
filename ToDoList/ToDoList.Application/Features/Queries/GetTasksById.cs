using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Queries
{
    public class GetTasksById: IRequest<List<UserTask>>
    {
        public int Id { get; }

        public GetTasksById(int Id)
        {
           this.Id = Id;
        }


    }
    public class GetTasksByIdHandler : IRequestHandler<GetTasksById, List<UserTask>>
    {
        private readonly IUserTaskRepository userTaskRepository;
        private readonly IMapper _mapper;

        public GetTasksByIdHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            this.userTaskRepository = userTaskRepository;
            _mapper = mapper;
        }

        public async Task<List<UserTask>> Handle(GetTasksById request, CancellationToken cancellationToken)
        {
            return await userTaskRepository.GetById(request.Id);
        }
    }

}
