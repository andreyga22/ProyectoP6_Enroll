using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class Enrollment
{
    public int Id { get; set; }

    public string IdEnrollment { get; set; } = null!;

    public DateOnly Date { get; set; }

    public float TotalPrice { get; set; }

    public int IdStudent { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual Student IdStudentNavigation { get; set; } = null!;

    public virtual ICollection<Payement> Payements { get; set; } = new List<Payement>();
}
