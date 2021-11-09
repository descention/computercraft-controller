
using System.Collections.Generic;
using System.Threading.Tasks;
using cc_turtle_manager_lib.Model;

namespace cc_turtle_manager_lib.Context
{
    public interface IComputerContext
    {
        Task<IComputer> GetComputerAsync(int id);
        Task<IEnumerable<IComputer>> GetComputersAsync();
        Task CreateComputerAsync(IComputer computer);
        Task UpdateComputerAsync(int id, IComputer computer);
        Task DeleteComputerAsync(int id);
        Task UpdateInventoryAsync(int id, IEnumerable<IContainerSlot> inventory);
    }
}