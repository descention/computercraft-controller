using System.ComponentModel.DataAnnotations;

namespace cc_turtle_manager.Dtos
{
    public struct UpdateLocationDto
    {
        int x{get;set;}
        int y{get;set;}
        int z{get;set;}

        byte facing{get;set;}
    }
}