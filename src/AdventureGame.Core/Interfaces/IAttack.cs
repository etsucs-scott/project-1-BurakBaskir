using AdventureGame.Core.Models;

namespace AdventureGame.Core.Interfaces;

    public interface IAttack
    {
        int Attack(ICharacter character); 
    }
