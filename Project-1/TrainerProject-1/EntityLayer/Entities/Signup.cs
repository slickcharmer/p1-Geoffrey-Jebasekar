using System;
using System.Collections.Generic;

namespace EntityLayer.Entities;

public partial class Signup
{
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phoneno { get; set; } = null!;

    public int Age { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; } = new List<Company>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual Login? Login { get; set; }

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
