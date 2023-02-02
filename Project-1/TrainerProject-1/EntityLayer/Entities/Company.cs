using System;
using System.Collections.Generic;

namespace EntityLayer.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Emailid { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Experience { get; set; }

    public virtual Signup Email { get; set; } = null!;
}
