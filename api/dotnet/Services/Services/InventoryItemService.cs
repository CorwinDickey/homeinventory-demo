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
        public async Task<InventoryItemDto> CreateAsync(
            InventoryItemDto itemDto)
        {
            var item = mapper.Map<InventoryItem>(itemDto);

            await repoContext.AddAsync(item);
            await repoContext.SaveAsync();

            return mapper.Map<InventoryItemDto>(item);
        }

        /// <inheritdoc/>
        public async Task<InventoryItemDto> UpdateAsync(
            ApplicationUser user, InventoryItemDto itemDto)
        {
            var item = repoContext.Get<InventoryItem>()
                .FirstOrDefault(x =>
                    x.Id == itemDto.Id
                    && x.CreatedUserId == user.Id) ??
                throw new EntityNotFoundException(
                    $"No Inventory Item found with id: {itemDto.Id}");

            var updatedItem = mapper.Map<InventoryItem>(itemDto);
            updatedItem.ParentEntityId = item.Id;

            await repoContext.AddAsync(updatedItem);
            await repoContext.SaveAsync();

            return mapper.Map<InventoryItemDto>(updatedItem);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(ApplicationUser user, int id)
        {
            var item = repoContext.Get<InventoryItem>()
                .FirstOrDefault(x =>
                    x.Id == id
                    && x.CreatedUserId == user.Id
                    && x.DeletedDate == null) ??
                throw new EntityNotFoundException(
                    $"No Inventory Item found with id: {id}");

            var deletedItem = mapper.Map<InventoryItem>(item);
            deletedItem.DeletedDate = DateTime.UtcNow;

            await repoContext.AddAsync(deletedItem);
            await repoContext.SaveAsync();
        }

        /// <inheritdoc/>
        public ICollection<InventoryItemDto> GetAll(
            ApplicationUser user)
        {
            // get all non-deleted items the user has access to
            var items = repoContext.Get<InventoryItem>()
                .Where(x =>
                    x.CreatedUserId == user.Id
                    && x.DeletedDate == null)
                .ToList();

            // find all items identified as a "parent" to another item
            var parentIds = items.Select(x => x.ParentEntityId).ToList();

            // find the items that are not a parent to another item
            var terminalItems = items
                .Where(x => !parentIds.Contains(x.Id)).ToList();

            return mapper.Map<
                ICollection<InventoryItem>,
                ICollection<InventoryItemDto>>(terminalItems);
        }

        /// <inheritdoc/>
        public ICollection<InventoryItemDto> GetAllWithHistory(
            ApplicationUser user)
        {
            // get all non-deleted items the user has access to
            var items = repoContext.Get<InventoryItem>()
                .Where(x =>
                    x.CreatedUserId == user.Id
                    && x.DeletedDate == null)
                .ToList();

            return mapper.Map<
                ICollection<InventoryItem>,
                ICollection<InventoryItemDto>>(items);
        }

        /// <inheritdoc/>
        public ICollection<InventoryItemDto> GetAllDeleted(
            ApplicationUser user)
        {
            // get all deleted items the user has access to
            var items = repoContext.Get<InventoryItem>()
                .Where(x =>
                    x.CreatedUserId == user.Id
                    && x.DeletedDate != null)
                .ToList();

            return mapper.Map<
                ICollection<InventoryItem>,
                ICollection<InventoryItemDto>>(items);
        }
    }
}
