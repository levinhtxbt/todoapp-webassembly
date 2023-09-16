using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.Api.Entities;

public class User : IdentityUser<Guid>
{

    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    [Required]
    public string LastName { get; set; } = string.Empty;

}
