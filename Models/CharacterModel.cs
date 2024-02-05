using System.ComponentModel.DataAnnotations;

namespace DT191G_Mom2.Models;

public class CharacterModel
{
    //Properties
    [Required(ErrorMessage = "Ange ett namn")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Namnet måste vara mellan 2 och 20 tecken långt")]
    [Display(Name="Namn")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Välj en klass")]
    [Display(Name="Klass")]
    public string? Class { get; set; }

    [Required(ErrorMessage = "Välj en ras")]
    [Display(Name="Ras")]
    public string? Race { get; set; }

    [Required(ErrorMessage = "Välj en bakgrund")]
    [Display(Name="Bakgrund")]
    public string? Background { get; set; }

    [Required(ErrorMessage = "Välj alignment")]
    public string? Alignment { get; set; }
}
