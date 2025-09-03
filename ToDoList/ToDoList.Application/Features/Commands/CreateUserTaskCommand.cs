using AutoMapper;
using MediatR;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Commands
{
    public class CreateUserTaskCommand : IRequest<int>
    {
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public int UserID { get; set; }
        public int State { get; set; }
    }

    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, int>
    {
        private readonly IUserTaskRepository userTaskRepository;
        private readonly IMapper _mapper;

        public CreateUserTaskCommandHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            this.userTaskRepository = userTaskRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var userTask = _mapper.Map<UserTask>(request);
            await userTaskRepository.AddAsync(userTask);
            return userTask.Id;
        }
    }
}
