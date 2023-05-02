using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Models;

public partial class Companie
{
    public string Name { get; set; } = null!;

    public DateTime? DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public string? Description { get; set; }
}
