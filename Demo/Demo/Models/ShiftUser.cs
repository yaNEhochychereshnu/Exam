﻿using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class ShiftUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ShiftId { get; set; }

    public virtual Shift Shift { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
