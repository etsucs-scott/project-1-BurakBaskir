using AdventureGame.Core.Models;

namespace AdventureGame.Core.Interfaces;

    public interface ICharacter
    {
        public int Health { get; set; } 
        int BaseDamage{get;}
}
