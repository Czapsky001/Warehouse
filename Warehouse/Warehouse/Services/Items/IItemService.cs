﻿using Warehouse.Lists.Items;

namespace Warehouse.Services.Items;

public interface IItemService
{
    Task<bool> AddItemAsync(Item item);
    Task<bool> RemoveItemAsync(Item item);
    Task<bool> UpdateItemAsync(Item item);
    Task<IEnumerable<Item>> GetAllItemsAsync();

    Task<Item> GetItemByIdAsync(int id);

}