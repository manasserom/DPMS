using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Data;

public partial class TechStack
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
