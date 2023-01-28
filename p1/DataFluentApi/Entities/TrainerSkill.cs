using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TrainerSkill
{
    public int Id { get; set; }

    public string? Skill { get; set; }

    public int Trainerskillid { get; set; }

    public virtual TrainerDetail Trainerskill { get; set; } = null!;
}
