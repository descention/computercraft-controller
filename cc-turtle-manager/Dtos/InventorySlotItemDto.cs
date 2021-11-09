using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager.Dtos
{
    public struct InventorySlotItemDto
    {
        [Required]
        public string Name{get;set;}

        [Required]
        [Range(0, short.MaxValue)]
        public short Count{get;set;}

        [Required]
        [Range(1,short.MaxValue)]
        public short Slot{get;set;}
    }
}