using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class CourseProfessor
{
    public int IdCourse { get; set; }

    public int IdProfessor { get; set; }

    public int Id { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Professor IdProfessorNavigation { get; set; } = null!;
}
