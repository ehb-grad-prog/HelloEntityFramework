using System.ComponentModel.DataAnnotations;

namespace HelloEntityFramework.Models;

public class CreateTranslationModel
{
    [Required, MinLength(3)]
    public string Key { get; set; } = null!;

    [Required(ErrorMessage = "You must specify a {0}!"), MinLength(3)]
    public string Value { get; set; } = null!;

    [Required(ErrorMessage = "You must specify a {0}!"), MinLength(2, ErrorMessage = "You have to specify a valid {0} ({1})"), MaxLength(5)]
    public string Language { get; set; } = null!;
}
