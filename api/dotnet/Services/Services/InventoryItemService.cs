using AutoMapper;
using Domain.Inventory;
using Domain.User;
using Repository;
using Services.Dtos;
using Services.Exceptions;
using Services.Interfaces;

namespace Services.Services
{
    /// <summary>
    /// Methods for interacting with Inventory Items
    /// </summary>
    /// <param name="repoContext">DB Context</param>
    /// <param name="mapper">AutoMapper</param>
    public class InventoryItemService(
        IRepoContext repoContext,
        IMapper mapper)
        : IInventoryItemService
    {
        /// <inheritdoc/>
        public async Task<InventoryItemDto> CreateInventoryItem(
            ApplicationUser user, InventoryItemDto itemDto)
        {
            var item = mapper.Map<InventoryItem>(itemDto);

            await repoContext.AddAsync(item);
            await repoContext.SaveAsync();

            return mapper.Map<InventoryItemDto>(item);
        }

        /// <inheritdoc/>
        public async Task<InventoryItemDto> UpdateInventoryItem(
            ApplicationUser user, InventoryItemDto itemDto)
        {
            var item = repoContext.Get<InventoryItem>()
                .FirstOrDefault(x => x.Id == itemDto.Id) ??
                throw new EntityNotFoundException($"No Inventory Item found with id: {itemDto.Id}");

            var mappedItem = mapper.Map<InventoryItem>(itemDto);
            var updatedItem = mapper.Map(mappedItem, item);

            await repoContext.AddAsync(updatedItem);
            await repoContext.SaveAsync();

            return mapper.Map<InventoryItemDto>(updatedItem);
        }

        /// <inheritdoc/>
        public async Task DeleteInventoryItem(ApplicationUser user, int id)
        {
            var item = repoContext.Get<InventoryItem>()
                .FirstOrDefault(x => x.Id == id) ??
                throw new EntityNotFoundException($"No Inventory Item found with id: {id}");

            var deletedItem = mapper.Map<InventoryItem>(item);
            deletedItem.DeletedDate = DateTime.UtcNow;

            await repoContext.AddAsync(deletedItem);
            await repoContext.SaveAsync();
        }
    }
}
