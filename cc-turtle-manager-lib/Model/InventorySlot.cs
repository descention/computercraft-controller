using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager_lib.Model
{
    public class InventorySlot:IContainerSlot
    {
        [Key]
        public IContainer Container { get;set; }
        
        [Key]
        public short Slot{get;set;}
        
        public string Name{get;set;}
        
        public short Count { get;set; }
    }
}