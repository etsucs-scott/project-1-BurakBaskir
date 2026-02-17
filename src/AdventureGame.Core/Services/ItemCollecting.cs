using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;

namespace AdventureGame.Core.Services;

public class ItemCollecting
{
    
    public string CollectItem(Player player, Item item)
    {
        player.Inventory.Add(item); 
        return item.PickUpMessage; 
    }
}