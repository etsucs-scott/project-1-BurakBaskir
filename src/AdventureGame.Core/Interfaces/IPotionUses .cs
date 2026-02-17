using AdventureGame.Core.Models;

namespace AdventureGame.Core.Interfaces;

public interface IPotionUses   // we might add new potions in the future, like power potion that gives extra damage, so we can use this interface for all potions
{
   public int UsePotion(HealthPotion potion);
}
