using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;

namespace AdventureGame.Core.Services;

public class FightLogic
{
    public string FightLoop(Player player, Monster monster)
    {
        string log = " FIGHT BEGINS!\n";
        log += $"Player HP: {player.Health} | Damage: {player.DamageDealt}\n";
        log += $"Monster HP: {monster.Health} | Damage: {monster.BaseDamage}\n\n";
        
        while (player.Health > 0 && monster.Health > 0)
        {
            player.Attack(monster);
            if (monster.Health <= 0)
            {
                log += $"\n You defeated the monster! Your HP: {player.Health}";
                break;
            }
            
            monster.Attack(player);
        }  
        
        if (player.Health <= 0)
        {
            log += "\n You have been defeated by the monster!";
        }
        
        return log;
    }
}