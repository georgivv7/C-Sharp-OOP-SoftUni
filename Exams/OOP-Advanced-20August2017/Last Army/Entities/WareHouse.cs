using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionsQuantities;
    private IAmmunitionFactory ammunitionFactory;
    public WareHouse()
    {
        ammunitionsQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }
    public void AddAmmunition(string ammunition, int quantity)
    {
        if (ammunitionsQuantities.ContainsKey(ammunition))
        {
            ammunitionsQuantities[ammunition] += quantity;
        }
        else
        {
            ammunitionsQuantities.Add(ammunition, quantity);
        }
    }
    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        bool isSoldierEquipped = true;
        foreach (var weapon in wornOutWeapons)
        {
            if (ammunitionsQuantities.ContainsKey(weapon) && ammunitionsQuantities[weapon] > 0)
            {
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
                ammunitionsQuantities[weapon]--;
            }
            else
            {
                isSoldierEquipped = false;
            }
        }
        return isSoldierEquipped;
    }
}
