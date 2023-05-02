using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Models;

public partial class Course
{
    public string Name { get; set; } = null!;

    public string Plataform { get; set; } = null!;

    public DateTime? DateEnd { get; set; }

    public string Path { get; set; } = null!;

    public string PathImages { get; set; } = null!;

    public string PathCertificated { get; set; } = null!;

    public virtual Plataform PlataformNavigation { get; set; } = null!;

    public virtual ICollection<TechStack> TechStacks { get; set; } = new List<TechStack>();
}
