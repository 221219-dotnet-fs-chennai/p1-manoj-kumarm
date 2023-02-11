using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TrainerEducation
{
    public int Id { get; set; }

    public string? Institute { get; set; }

    public string? Degreename { get; set; }

    public string? Gpa { get; set; }

    public string? Startdate { get; set; }

    public string? Enddate { get; set; }

    public int Trainereducationid { get; set; }

    public virtual TrainerDetail Trainereducation { get; set; } = null!;
}
