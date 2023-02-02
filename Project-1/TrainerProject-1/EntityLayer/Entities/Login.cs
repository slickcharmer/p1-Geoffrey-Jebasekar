using System;
using System.Collections.Generic;

namespace EntityLayer.Entities;

public partial class Login
{
    public string Emailid { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Signup Email { get; set; } = null!;
}
