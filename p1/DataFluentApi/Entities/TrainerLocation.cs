using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TrainerLocation
{
    public int Id { get; set; }

    public string Zipcode { get; set; } = null!;

    public string? City { get; set; }

    public int Trainerlocationid { get; set; }

    public virtual TrainerDetail Trainerlocation { get; set; } = null!;
}
