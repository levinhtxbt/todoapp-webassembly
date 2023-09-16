using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Model.Enums;

namespace TodoApp.Model.Dto
{
    public class NewTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Priority Priority { get; set; }
    }
}