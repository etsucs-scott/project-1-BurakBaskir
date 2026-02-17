using System;
using System.Collections.Generic;
using AdventureGame.Core.Interfaces;

namespace AdventureGame.Core.Models;

public class Player : ICharacter , IAttack , IPotionUses
{   
    private int health;
    
    public int Health 
    { 
        get 
        { 
            return health; 
        }
        set 
        { 
            if (value < 0)
                health = 0;
            else if (value > 150)
                health = 150;
            else 
                health = value;    
        }
    }
    
    public Weapon EquippedWeapon { get; set; }

    public Player()
    {
        health = 100;  
    }

    public int UsePotion(HealthPotion potion)
    {
        Health += potion.HealthRestores;
        return Health;
    }
    
    public int BaseDamage { get; } = 10;
    public const int playerBaseDamage = 10;
    public int DamageDealt 
    { 
        get 
        { 
            return BaseDamage + (EquippedWeapon?.DamageAdded ?? 0); 
        }
    }

    public string Name { get; set; }
    
    public int Attack(ICharacter monster)
    {
        monster.Health -= DamageDealt;
        return monster.Health;
    }
    
    public List<Item> Inventory { get; set; } = new List<Item>();
}