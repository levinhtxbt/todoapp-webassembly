﻿namespace TodoApp.Model.Dto;

public class AssignTaskDto
{
    public Guid TaskId { get; set; }
    
    public Guid AssigneeId { get; set; }
}