using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class CourseEnrollment
{
    public int IdCourse { get; set; }

    public int IdEnrollment { get; set; }

    public int Id { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Enrollment IdEnrollmentNavigation { get; set; } = null!;
}
