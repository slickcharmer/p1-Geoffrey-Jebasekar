using System;
using System.Collections.Generic;

namespace EntityLayer.Entities;

public partial class Skill
{
    public int Id { get; set; }

    public string Emailid { get; set; } = null!;

    public string Skill1 { get; set; } = null!;

    public int Profeciency { get; set; }

    public virtual Signup Email { get; set; } = null!;
}
