using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager.Dtos
{
    public struct UpdateInventoryDto
    {
        [Required]
        public List<InventorySlotItemDto> Inventory{get;set;}
    }
}