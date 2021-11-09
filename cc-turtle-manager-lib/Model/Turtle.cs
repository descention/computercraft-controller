using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager_lib.Model
{
    public class Turtle : ITurtle
    {
        [Key]
        public int ID { get; set; }

        public string Label{get;set;}
        public ICollection<IContainerSlot> Inventory{get;set;}
    }
}
