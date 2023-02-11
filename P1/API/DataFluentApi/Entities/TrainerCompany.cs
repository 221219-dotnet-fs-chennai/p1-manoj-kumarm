using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TrainerCompany
{
    public int Id { get; set; }

    public string? Companyname { get; set; }

    public string? Title { get; set; }

    public string? Startyear { get; set; }

    public string? Endyear { get; set; }

    public int Trainercompanyid { get; set; }

    public virtual TrainerDetail Trainercompany { get; set; } = null!;
}
