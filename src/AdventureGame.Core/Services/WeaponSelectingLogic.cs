using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;
using System.Collections.Generic;

namespace AdventureGame.Core.Services;

public class WeaponSelectingLogic
{
    public void SelectWeapon(Player player)
    {
        player.EquippedWeapon = null;
        int damageIncreased = 0;
        
        foreach(Item equiment in player.Inventory)
        {
            if (equiment is Weapon weapon)
            {
                if (weapon.DamageAdded > damageIncreased)
                {
                    player.EquippedWeapon = weapon;
                    damageIncreased = weapon.DamageAdded;
                }
            }
        }
    }
}