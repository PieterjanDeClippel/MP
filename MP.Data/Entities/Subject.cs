using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MP.Data.Entities;

public abstract class Subject
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public List<Medium> Media { get; set; }// = [];
    public List<Tag> Tags { get; set; }// = [];

    public User UserInsert { get; set; }
    public User? UserUpdate { get; set; }
    public User? UserDelete { get; set; }

    public DateTime DateInsert { get; set; }
    public DateTime? DateUpdate { get; set; }
    public DateTime? DateDelete { get; set; }
}
