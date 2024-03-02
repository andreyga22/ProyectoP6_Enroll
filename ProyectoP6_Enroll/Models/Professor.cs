using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class Professor
{
    public int Id { get; set; }

    public string IdProfessor { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Assignment { get; set; } = null!;

    public virtual ICollection<CourseProfessor> CourseProfessors { get; set; } = new List<CourseProfessor>();
}
