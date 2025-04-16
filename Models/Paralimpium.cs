using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API250416.Models;

[Table("paralimpia")]
public partial class Paralimpium
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("orszag")]
    [StringLength(20)]
    [Unicode(false)]
    public string Orszag { get; set; } = null!;

    [Column("varos")]
    [StringLength(20)]
    [Unicode(false)]
    public string Varos { get; set; } = null!;

    [Column("ev")]
    public int Ev { get; set; }

    [Column("arany")]
    public int? Arany { get; set; }

    [Column("ezust")]
    public int? Ezust { get; set; }

    [Column("bronz")]
    public int? Bronz { get; set; }
}
