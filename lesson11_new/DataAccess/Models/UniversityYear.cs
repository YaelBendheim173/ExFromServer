﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UniversityYear
{
    public int? UniversityId { get; set; }

    public int? Year { get; set; }

    public int? NumStudents { get; set; }

    public decimal? StudentStaffRatio { get; set; }

    public int? PctInternationalStudents { get; set; }

    public int? PctFemaleStudents { get; set; }

    public virtual University? University { get; set; }
}
