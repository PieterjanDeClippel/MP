namespace MintPlayer.Dtos;

public class TagDto
{
	public int Id { get; set; }
	public string Description { get; set; }
	public TagCategoryDto Category { get; set; }
	public TagDto? Parent { get; set; }
	public List<TagDto> Children { get; set; }
}
