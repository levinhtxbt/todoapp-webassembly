using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Model.Enums;

namespace TodoApp.Model.Dto
{
    public class UpdateTaskDto
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; }

        [FromBody]
        public UpdateTaskData Data { get; set; }

    }

    public class UpdateTaskData
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Guid? AssigneeId { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }
    }
}