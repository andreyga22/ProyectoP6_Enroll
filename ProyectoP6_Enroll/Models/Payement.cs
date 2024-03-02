using System;
using System.Collections.Generic;

namespace ProyectoP6_Enroll.Models;

public partial class Payement
{
    public int Id { get; set; }

    public string IdPayment { get; set; } = null!;

    public string Date { get; set; } = null!;

    public bool Status { get; set; }

    public int IdEnrollment { get; set; }

    public virtual Enrollment IdEnrollmentNavigation { get; set; } = null!;
}
