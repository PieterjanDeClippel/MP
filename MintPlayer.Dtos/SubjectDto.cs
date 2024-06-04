namespace MintPlayer.Dtos;

public class SubjectDto
{
    public int Id { get; set; }
    public List<MediumDto> Media { get; set; } = new List<MediumDto>();
    public List<TagDto> Tags { get; set; } = new List<TagDto>();
}
