using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;
using System.Linq;

namespace AdventureGame.Core.Services;

public class PotionConsumeLogics  // we might add new potion logics as well such as power potion under this class
{ 
    // ask when i cast potion type how i am keeping potion fields like amound of health it restores, inventory is item type list 
    
    public string UseHealthPotion(Player player)   
    {  
        Item potioncheck = player.Inventory.FirstOrDefault(i => i is HealthPotion);
        if (potioncheck != null)
        {
            HealthPotion p = (HealthPotion)potioncheck;
            player.UsePotion(p); 
            player.Inventory.Remove(p); 
            return $"Used a {p.Name}! Health is now {player.Health}."; 
        }
        else
        {
            return "No Health Potion to use!";
        }
    }
}