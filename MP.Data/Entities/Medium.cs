using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MP.Data.Entities;

public class Medium
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Value { get; set; }

    public int TypeId { get; set; }
    public MediumType? Type { get; set; }


    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
}
