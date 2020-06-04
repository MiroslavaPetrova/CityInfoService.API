using System.ComponentModel.DataAnnotations;

namespace CityInfoService.API.Dtos
{
    public class CityForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
