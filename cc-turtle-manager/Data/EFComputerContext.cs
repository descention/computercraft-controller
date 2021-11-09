using Microsoft.EntityFrameworkCore;
using cc_turtle_manager_lib.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using cc_turtle_manager_lib.Context;
using System.Linq;

namespace cc_turtle_manager.Data
{
    public class EFComputerContext : DbContext, IComputerContext
    {
        public EFComputerContext(DbContextOptions<EFComputerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Turtle> Computers { get; set; }
        public DbSet<InventorySlot> InventorySlots{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            modelBuilder.Entity<Turtle>()
                .HasMany<InventorySlot>("Inventory")
                .WithOne();

            modelBuilder.Entity<InventorySlot>()
                .HasOne<Turtle>("Container");

            base.OnModelCreating(modelBuilder);  
        } 

        public async Task CreateComputerAsync(IComputer computer)
        {
            if(computer.ID == 0)
                throw new ArgumentException();
            
            await Computers.AddAsync(computer as Turtle);
            await SaveChangesAsync();
        }

        public async Task DeleteComputerAsync(int id)
        {
            var turtle = await Computers.FindAsync(id);
            if(turtle != null){
                Computers.Remove(turtle);
                await this.SaveChangesAsync();
            }
        }

        public async Task<IComputer> GetComputerAsync(int id) => await Computers.FindAsync(id);
        public async Task<IEnumerable<IComputer>> GetComputersAsync() => await Computers.ToListAsync();
        public async Task UpdateComputerAsync(int id, IComputer computer)
        {
            if (id != computer.ID)
            {
                throw new InvalidOperationException();
            }

            Entry(computer).State = EntityState.Modified;

            try
            {
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ComputerExists(id))
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task UpdateInventoryAsync(int id, IEnumerable<IContainerSlot> inventory)
        {
            var computer = await GetComputerAsync(id);
            if(computer == null)
                throw new ArgumentException("Computer doesn't exist");
            var turtle = computer as Turtle;
            if(turtle == null)
                throw new InvalidCastException("Computer isn't a turtle");

            if(turtle.Inventory == null)
                turtle.Inventory = new List<IContainerSlot>();
            
            foreach(var item in inventory.Cast<InventorySlot>())
            {
                item.Container = turtle;
                var slot = turtle.Inventory.SingleOrDefault(t=>t.Slot == item.Slot);
                if(slot == null)
                {
                    turtle.Inventory.Add(item);
                    await InventorySlots.AddAsync(item);
                }
                else
                {
                    slot.Name = item.Name;
                    slot.Count = item.Count;
                }
            }

            await SaveChangesAsync();
        }

        private async Task<bool> ComputerExists(int id) => await Computers.AnyAsync(t=>t.ID == id);
    }
}
