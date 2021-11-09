using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager.Dtos
{
    public struct CreateComputerDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int ID{get;set;}
    }
}