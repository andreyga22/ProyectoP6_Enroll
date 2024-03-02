using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class Course
{
    public int Id { get; set; }

    public string IdCourse { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Faculty { get; set; } = null!;

    public float Price { get; set; }

    public int IdLocation { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<CourseProfessor> CourseProfessors { get; set; } = new List<CourseProfessor>();

    public virtual Location IdLocationNavigation { get; set; } = null!;
}
