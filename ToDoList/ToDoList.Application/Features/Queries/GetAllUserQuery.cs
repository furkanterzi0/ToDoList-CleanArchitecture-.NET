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
    public class GetAllUserQuery : IRequest<List<UserDTO>> { }

    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserDTO>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync(); 
            return _mapper.Map<List<UserDTO>>(users);       // DTO'ya dönüştür
        }
    }
}
