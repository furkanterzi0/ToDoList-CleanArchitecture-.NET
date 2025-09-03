using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;

namespace ToDoList.Application.Validators
{
    public class UserDTOValidator: AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x=> x.FirstName).NotEmpty().WithMessage("first name is required");
            RuleFor(x => x.Username).NotEmpty().WithMessage("username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("email is required");
        }
    }
}
