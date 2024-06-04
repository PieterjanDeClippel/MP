using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MP.Data.Entities;

[PrimaryKey(nameof(SubjectId), nameof(TagId))]
public class SubjectTag
{
    public int SubjectId { get; set; }
    //public Subject Subject { get; set; }

    public int TagId { get; set; }
    //public Tag Tag { get; set; }
}
