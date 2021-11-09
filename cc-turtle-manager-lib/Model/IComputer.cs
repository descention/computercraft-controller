using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager_lib.Model
{
    public interface IComputer
    {
        [Key]
        int ID { get; set; }
        string Label { get; set; }
    }
}
