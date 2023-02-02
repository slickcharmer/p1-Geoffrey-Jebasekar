using System;
using System.Collections.Generic;

namespace EntityLayer.Entities;

public partial class Education
{
    public int Id { get; set; }

    public string Emailid { get; set; } = null!;

    public string EducationType { get; set; } = null!;

    public string InstituteName { get; set; } = null!;

    public string Stream { get; set; } = null!;

    public string StartYear { get; set; } = null!;

    public string EndYear { get; set; } = null!;

    public string Percentage { get; set; } = null!;

    public virtual Signup Email { get; set; } = null!;
}
