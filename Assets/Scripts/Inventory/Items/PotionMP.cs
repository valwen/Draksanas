using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/PotionMP")]

public class PotionMP : Item
{

    public override void Use()
    {
        base.Use();
        DrinkPotion();
    }

    public void DrinkPotion()
    {

        Debug.Log("DRINK");

        if (playerAbilities.playerCurrentMP <= (playerAbilities.playerMaxMP) * 0.75)
        {
            playerAbilities.regenSpeed = 3;
            playerAbilities.time = 15f;
        }

        else if (playerAbilities.playerCurrentMP <= (playerAbilities.playerMaxMP) * 0.5)
        {
            playerAbilities.regenSpeed = 8;
            playerAbilities.time = 10f;
        }

        else if (playerAbilities.playerCurrentMP <= (playerAbilities.playerMaxMP) * 0.25)
        {
            playerAbilities.regenSpeed = 10;
            playerAbilities.time = 6f;
        }

        Inventory.instance.Remove(this);

    }

}
