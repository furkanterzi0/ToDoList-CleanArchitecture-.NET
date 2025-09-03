using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.DTOs
{
    public class UserTaskDTO: BaseEntity
    {
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        public int State { get; set; }
        public int UserId { get; set; }
    }
}
