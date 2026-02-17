namespace AdventureGame.Core.Models;

public abstract class Item
{
    public string Name { get; protected set; }
    public abstract string PickUpMessage { get;}

}
public class Weapon : Item
{
    public int DamageAdded { get; set; }
    public Weapon(string name, int damageAdded)
    {
        Name = name;
        DamageAdded = damageAdded;
    }
    public override string PickUpMessage => $"You have picked up a {Name} if used adds {DamageAdded} damage to your attack";
}

public abstract class Potion : Item // i made this class because i wanted to use potion type for IPotionUses interface to make it more flexible for future potion types, 
{}

public class HealthPotion : Potion // specificly i gave HealhPotion name to this potion class because we might add new potion types such as power potion in the future and we can keep them under item class without messing each other
{   
    public int HealthRestores { get; set; }     // we can add big and little health potions with different health restore values 
    public HealthPotion(string name, int healthRestores)
    {
        Name = name;
        HealthRestores = healthRestores;
    }
    public override string PickUpMessage => $"You have picked up a {Name} if used restores {HealthRestores} health";
}