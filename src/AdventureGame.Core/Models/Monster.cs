using System;
using AdventureGame.Core.Interfaces;

namespace AdventureGame.Core.Models;

public class Monster : ICharacter
{
    private Random random1 = new Random();
    public const int monsterBaseDamage = 10;
    private int health; 
    
    public int Health 
    { 
        get 
        { 
            return health; 
        }
        set 
        { 
            if(value < 0) 
                health = 0; 
            else 
                health = value; 
        } 
    }
    
    public int BaseDamage { get; set; }

    public Monster() 
    {
        health = random1.Next(30, 51);  
        BaseDamage = monsterBaseDamage;
    }
    
    public int Attack(ICharacter player)
    {
        player.Health -= BaseDamage;
        return player.Health;
    }
}