using Microsoft.AspNetCore.Identity;

namespace MP.Data.Entities;

public class User : IdentityUser<Guid>
{
    public string PictureUrl { get; set; }
    public bool Bypass2faForExternalLogin { get; set; }
}
