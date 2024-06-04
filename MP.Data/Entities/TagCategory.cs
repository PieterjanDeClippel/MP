using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MP.Data.Entities;

public class TagCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Color Color { get; set; }
    public string Description { get; set; }

    public List<Tag> Tags { get; set; }

    //public User UserInsert { get; set; }
    //public User UserUpdate { get; set; }
    //public User UserDelete { get; set; }

    //public DateTime DateInsert { get; set; }
    //public DateTime? DateUpdate { get; set; }
    //public DateTime? DateDelete { get; set; }
}
