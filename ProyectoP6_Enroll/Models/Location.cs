using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class Location
{
    public int Id { get; set; }

    public string IdLocation { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
