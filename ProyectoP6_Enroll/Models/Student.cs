using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class Student
{
    public int Id { get; set; }

    public string IdStudent { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
