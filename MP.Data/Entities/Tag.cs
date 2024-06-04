using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MP.Data.Entities;

public class Tag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Description { get; set; }
    public TagCategory Category { get; set; }
    public Tag Parent { get; set; }
    public List<Tag> Children { get; set; }
    public List<Subject> Subjects { get; set; }

    public User UserInsert { get; set; }
    public User UserUpdate { get; set; }
    public User UserDelete { get; set; }

    public DateTime DateInsert { get; set; }
    public DateTime? DateUpdate { get; set; }
    public DateTime? DateDelete { get; set; }
}
