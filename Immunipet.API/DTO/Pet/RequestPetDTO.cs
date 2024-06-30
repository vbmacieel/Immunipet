using System.ComponentModel.DataAnnotations;

namespace Immunipet.API.DTO.Pet;

class RequestPetDTO
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthday { get; set; }
}