using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MintPlayer.Dtos;
using MP.Data;
using System.Drawing;

namespace MP.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private readonly MintPlayerContext context;
    public SongController(MintPlayerContext context)
    {
        this.context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<SongDto> Get()
    {
        if (!context.Songs.Any())
        {
            await context.Songs.AddAsync(new Data.Entities.Song
            {
                Id = 23,
                Title = "A Sky Full of Stars",
                Media = [
                    new Data.Entities.Medium
                    {
                        Type = new Data.Entities.MediumType { Description = "Youtube" },
                        Value = "https://www.youtube.com/watch?v=zp7NtW_hKJI"
                    }
                ],
                Tags = [
                    new Data.Entities.Tag
                    {
                        Description = "Electronic Dance Music",
                        Category = new Data.Entities.TagCategory
                        {
                            Color = Color.Green,
                            Description = "Genre"
                        }
                    }
                ],
            });
            await context.SaveChangesAsync();
        }


        var song = await context.Songs
            .Include(s => s.Media)
                .ThenInclude(m => m.Type)
            // Comment out includes below to make it work
            .Include(s => s.Tags)
                .ThenInclude(t => t.Category)
            //.AsNoTracking()
            .SingleOrDefaultAsync(s => s.Id == 23);

        return new SongDto
        {
            Id = song.Id,
            Title = song.Title,
            Media = song.Media.Select(m => new MediumDto
            {
                Id = m.Id,
                Type = new MediumTypeDto
                {
                    Id = m.Type.Id,
                    Description = m.Type.Description,
                },
                Value = m.Value,
            }).ToList(),
            Tags = (song.Tags ?? []).Select(t => new TagDto
            {
                Id = t.Id,
                Description = t.Description,
                Category = new TagCategoryDto
                {
                    Id = t.Category.Id,
                    Description = t.Category.Description,
                }
            }).ToList(),
        };
    }
}
