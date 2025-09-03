using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Queries
{
    public class GetAllUserTaskQuery : IRequest<List<UserTaskDTO>> { }

    public class GetAllUserTaskQueryHandler : IRequestHandler<GetAllUserTaskQuery, List<UserTaskDTO>>
    {
        private readonly IUserTaskRepository userTaskRepository;
        private readonly IMapper _mapper;

        public GetAllUserTaskQueryHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            this.userTaskRepository = userTaskRepository;
            _mapper = mapper;
        }

        public async Task<List<UserTaskDTO>> Handle(GetAllUserTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await userTaskRepository.GetAllAsync(); 
            return _mapper.Map<List<UserTaskDTO>>(tasks);       // DTO
        }
    }
}
