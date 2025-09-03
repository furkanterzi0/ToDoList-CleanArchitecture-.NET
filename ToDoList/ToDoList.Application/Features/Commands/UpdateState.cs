using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Commands
{
    public class UpdateState: IRequest<int>
    {
        public int Id { get; }
        public int State { get; set; }
        public UpdateState(int Id, int State)
        {
            this.Id = Id;
            this.State = State;
        }
    }
    public class UpdateStateHandler : IRequestHandler<UpdateState, int>
    {
        private readonly IUserTaskRepository userTaskRepository;
        private readonly IMapper _mapper;

        public UpdateStateHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            this.userTaskRepository = userTaskRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateState request, CancellationToken cancellationToken)
        {
            
            return await userTaskRepository.UpdateState(request.Id, request.State);
        }
    }
}
