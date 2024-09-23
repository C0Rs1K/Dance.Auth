﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dance.Auth.DataAccess.Models;

public class User : IdentityUser<Guid>
{
    [MaxLength(256)]
    public string Name { get; set; }
}