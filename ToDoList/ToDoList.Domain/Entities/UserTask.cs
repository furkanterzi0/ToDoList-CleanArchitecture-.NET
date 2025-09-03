using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Entities
{
    public class UserTask: BaseEntity
    {   
        public string Title{ get; set; }
        public DateTime EndDate{ get; set; }
        public int State { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
