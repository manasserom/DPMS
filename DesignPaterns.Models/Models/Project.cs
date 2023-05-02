using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Models;

public partial class Project
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string PathImages { get; set; } = null!;

    public bool LinkedIn { get; set; }

    public bool GitHub { get; set; }

    public string? ToPerfect { get; set; }

    public string? Others { get; set; }

    public virtual ICollection<TechStack> TechStacks { get; set; } = new List<TechStack>();
}
