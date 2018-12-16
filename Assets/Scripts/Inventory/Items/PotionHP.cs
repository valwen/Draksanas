using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/PotionHP")]

public class PotionHP : Item
{

        public override void Use()
    {
        base.Use();
        DrinkPotion();
    }

    public void DrinkPotion()
    {
        
        Debug.Log("DRINK");

        if (playerAbilities.playerCurrentHP <= (playerAbilities.playerMaxHP) * 0.75)
        {
            playerAbilities.regenSpeed = 3;
            playerAbilities.time = 7f;
        }

        else if (playerAbilities.playerCurrentHP <= (playerAbilities.playerMaxHP) * 0.5)
        {
            playerAbilities.regenSpeed = 8;
            playerAbilities.time = 5f;
        }

        else if (playerAbilities.playerCurrentHP <= (playerAbilities.playerMaxHP) * 0.25)
        {
            playerAbilities.regenSpeed = 10;
            playerAbilities.time = 4f;
        }

        Inventory.instance.Remove(this);

    }

}
