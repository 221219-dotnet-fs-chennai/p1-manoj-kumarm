using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TrainerDetail
{
    public string? Fullname { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Aboutme { get; set; }

    public string? Gender { get; set; }

    public string? Age { get; set; }

    public int Trainerid { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<TrainerCompany> TrainerCompanies { get; } = new List<TrainerCompany>();

    public virtual ICollection<TrainerEducation> TrainerEducations { get; } = new List<TrainerEducation>();

    public virtual TrainerLocation? TrainerLocation { get; set; }

    public virtual ICollection<TrainerSkill> TrainerSkills { get; } = new List<TrainerSkill>();
}
