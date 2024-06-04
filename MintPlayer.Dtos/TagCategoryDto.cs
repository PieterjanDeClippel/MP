using System.Drawing;
using System.Formats.Asn1;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MintPlayer.Dtos;

public class TagCategoryDto
{
	public int Id { get; set; }

	//[JsonConverter(typeof(Converters.HtmlColorConverter))]
	//public Color Color { get; set; }
	public string Description { get; set; }
	public List<TagDto> Tags { get; set; }
}

//internal class HtmlColorConverter : JsonConverter
//{
//    public HtmlColorConverter() : base()
//    {
//    }

//    public override bool CanConvert(Type typeToConvert)
//    {
//        return (typeToConvert == typeof(System.Drawing.Color));
//    }

//    //public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//    //{
//    //    return System.Drawing.ColorTranslator.FromHtml((string)reader.Value);
//    //}

//    //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//    //{
//    //    writer.WriteValue(System.Drawing.ColorTranslator.ToHtml((System.Drawing.Color)value));
//    //}
//    public override Type? Type => throw new NotImplementedException();

//}
