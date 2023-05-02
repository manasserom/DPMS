using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Data;

public partial class Plataform
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
