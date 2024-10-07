﻿using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class Trainer : BaseEntity
{
    public int WorkExperience { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public virtual List<DanceClass> DanceClasses { get; set; }
}