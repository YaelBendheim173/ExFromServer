﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class University
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public string? UniversityName { get; set; }

    public virtual Country? Country { get; set; }
}