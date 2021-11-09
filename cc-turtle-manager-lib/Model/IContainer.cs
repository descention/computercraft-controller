using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager_lib.Model
{
    public interface IContainer
    {
        [Key]
        int ID{get;set;}
        ICollection<IContainerSlot> Inventory{get;set;}
    }
}