using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.DTOs;

namespace ToDoList.Application.Validators
{
    public class UserTaskDTOValidator: AbstractValidator<UserTaskDTO>
    {
        public UserTaskDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("title is required");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("end date is required");
        }
    }
}
