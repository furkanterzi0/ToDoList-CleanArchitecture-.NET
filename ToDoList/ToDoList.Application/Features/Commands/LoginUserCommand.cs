using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Commands
{
    public class LoginUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }



        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
        {
            private readonly IUserRepository userRepository;

            public LoginUserCommandHandler(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }

            public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await userRepository.GetUser(request.Username, request.Password);

                return user;
            }
        }
    }
}
