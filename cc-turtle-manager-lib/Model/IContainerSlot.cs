using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager_lib.Model
{
    public interface IContainerSlot
    {
        [Key]
        IContainer Container { get; set; }

        [Key] 
        short Slot{get;set;}
                
        string Name{get;set;}

        [Range(0,64)]
        short Count{get;set;}
        
    }
}